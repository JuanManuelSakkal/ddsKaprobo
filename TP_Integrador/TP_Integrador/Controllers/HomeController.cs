using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Integrador.Clases;
using TP_Integrador.Helpers;
using TP_Integrador.Data;
using System.Web.Caching;
using System.Data.Entity;

namespace TP_Integrador.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            System.Diagnostics.Debug.WriteLine("Holissss4321");
        }
        Simplex unaConsultaSimplex;
        public void CacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            System.Diagnostics.Debug.WriteLine("Cache item callback: " + DateTime.Now.ToString());
            //ViewData["result"] = unaConsultaSimplex.Ejecutar();
            HttpContext.Cache.Add("Prueba", "Prueba2", null, DateTime.MaxValue, TimeSpan.FromSeconds(5), CacheItemPriority.Normal, new CacheItemRemovedCallback(CacheItemRemovedCallback));
        }

        public ActionResult Index()
        {
            //Scheduler.Schedule();
            HttpContext.Cache.Add("Prueba", "Prueba2", null, DateTime.MaxValue, TimeSpan.FromSeconds(5), CacheItemPriority.Normal, new CacheItemRemovedCallback(CacheItemRemovedCallback));

            //Importacion de usuarios - VER COMO PASAR A VISTA!!!!
            List<Cliente> clientes = ClienteImporter.ImportarUsuarios();
            ViewData["Clientes"] = clientes[0].UsuarioID + clientes[0].Apellido + clientes[0].Nombre + clientes[0].NombreUsuario + clientes[0].Password + clientes[0].TipoDoc + clientes[0].NumeroDoc + clientes[0].Telefono;

            //Importacion de administradores
            List<Administrador> administradores = AdministradorImporter.ImportarUsuarios();
            ViewData["Administradores"] = administradores[0].Apellido;

            //Importacion de dispositivos
            List<DispositivoInteligente> dispositivos = DispositivoImporter.ImportarDispositivosInteligentes();
            ViewData["Dispositivos"] = dispositivos[0].NombreDispositivo + dispositivos[0].KwPorHora;

            //PRUEBA SIMPLEX
            List<DispositivoInteligente> dispositivosInteligentes = DispositivoInteligenteHandler.GetDispositivoInteligentes();
            unaConsultaSimplex = new Simplex(dispositivosInteligentes);
            unaConsultaSimplex.AgregarRestriccion(440640, null, "<=");
            unaConsultaSimplex.AgregarRestriccion(90, dispositivosInteligentes[0], ">=");
            ViewData["ResultadoSimplex"] = unaConsultaSimplex.Ejecutar();

            //Prueba Entity Framework
            using (var db = new ContextoDB())
            {
                /*Categoria R1 = new Categoria("R1", 18.76, 0.644);
                db.Categorias.Add(R1);

                DispositivoInteligente aire3500 = new DispositivoInteligente("Aire 3500", 1.613, new FabricanteDePrueba());
                DispositivoInteligente aire2200 = new DispositivoInteligente("Aire 2200", 1.013, new FabricanteDePrueba());
                DispositivoInteligente tvLed40 = new DispositivoInteligente("TV Led 40", 0.08, new FabricanteDePrueba());

                db.Dispositivos.Add(aire2200);
                db.Dispositivos.Add(aire3500);
                db.Dispositivos.Add(tvLed40);

                db.SaveChanges();*/

                DispositivoInteligente aire2200 = null;
                DispositivoInteligente tvLed40 = null;
                var dispositivoQuery = from d in db.Dispositivos
                                orderby d.NombreDispositivo
                                select d;
                foreach (var item in dispositivoQuery)
                {
                    if (item.NombreDispositivo == "Aire Acondicionado 3500")
                    {
                        aire2200 = (DispositivoInteligente)item;
                    }
                    else if (item.NombreDispositivo == "TV LED 40")
                    {
                        tvLed40 = (DispositivoInteligente)item;
                    }
                }

                //DispositivoInteligente aire2200 = (DispositivoInteligente)db.Dispositivos.First(d => d.NombreDispositivo == "Aire Acondicionado 3500");
                //DispositivoInteligente tvLed40 = (DispositivoInteligente)db.Dispositivos.First(d => d.NombreDispositivo == "TV LED 40");

                //Creo un nuevo cliente
                Cliente unCliente = new Cliente();
                unCliente.UsuarioID = 1;
                unCliente.NombreUsuario = "sebikap";
                unCliente.Password = "LaContra1!";
                unCliente.Nombre = "Sebastian";
                unCliente.Apellido = "Kaplanski";
                unCliente.Domicilio = "Av Medrano 851";
                unCliente.FechaDeAlta = DateTime.Now;
                unCliente.TipoDoc = "DNI";
                unCliente.TipoDoc = "12345678";
                unCliente.Telefono = "4888-8888";
                unCliente.Categoria = CategoriaHandler.GetCategoriaDB("R1");
                unCliente.Puntos = 0;
                unCliente.Dispositivos.Add(aire2200);
                unCliente.Dispositivos.Add(tvLed40);

                System.Diagnostics.Debug.WriteLine("LCDTMAB AGREGO");
                db.Clientes.Add(unCliente);

                System.Diagnostics.Debug.WriteLine("LCDTMAB GUARDO");
                db.SaveChanges();

                var query = from b in db.Clientes where b.Apellido == "Kaplanski"
                            orderby b.Apellido
                            select b;

                foreach (var item in query)
                {
                    ViewData["ClienteDePrueba"] = item.Apellido + " " + item.Nombre + " " + item.Dispositivos[0].NombreDispositivo;
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}