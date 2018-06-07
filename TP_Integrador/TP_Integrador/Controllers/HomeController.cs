using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Integrador.Clases;
using TP_Integrador.Helpers;

namespace TP_Integrador.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            System.Diagnostics.Debug.WriteLine("Holissss4321");
        }

        public ActionResult Index()
        {
            //List<Cliente> listadoClientes = ClienteImporter.ImportarUsuarios();
            //ViewBag["NombrePrueba"] = listadoClientes[0].nombre;
            ViewBag.Title = "Prueba";
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