﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Integrador.Clases;
using TP_Integrador.Helpers;
using System.Web.Caching;

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
            ViewData["result"] = unaConsultaSimplex.Ejecutar();
            HttpContext.Cache.Add("Prueba", "Prueba2", null, DateTime.MaxValue, TimeSpan.FromSeconds(5), CacheItemPriority.Normal, new CacheItemRemovedCallback(CacheItemRemovedCallback));
        }

        public ActionResult Index()
        {
            //Scheduler.Schedule();
            HttpContext.Cache.Add("Prueba", "Prueba2", null, DateTime.MaxValue, TimeSpan.FromSeconds(5), CacheItemPriority.Normal, new CacheItemRemovedCallback(CacheItemRemovedCallback));

            //Importacion de usuarios
            List<Cliente> clientes = ClienteImporter.ImportarUsuarios();
            ViewData["Clientes"] = clientes[0].idUsuario + clientes[0].apellido + clientes[0].nombre + clientes[0].nombreUsuario + clientes[0].password + clientes[0].tipoDoc + clientes[0].numeroDoc + clientes[0].telefono;

            //PRUEBA SIMPLEX
            List<DispositivoInteligente> dispositivos = DispositivoInteligenteHandler.GetDispositivoInteligentes();
            unaConsultaSimplex = new Simplex(dispositivos);
            unaConsultaSimplex.AgregarRestriccion(440640, null, "<=");
            unaConsultaSimplex.AgregarRestriccion(90, dispositivos[0], ">=");
            

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