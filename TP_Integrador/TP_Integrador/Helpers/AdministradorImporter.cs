using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TP_Integrador.Clases;

namespace TP_Integrador.Helpers
{
    public static class AdministradorImporter
    {
        static HttpServerUtility server = HttpContext.Current.Server;
        static string path = server.MapPath(@"~/json/Administradores.json");

        public static List<Administrador> ImportarUsuarios()
        {
            StreamReader rd = new StreamReader(path);
            List<Administrador> listadoAdministradores = new List<Administrador>();

            var listUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(rd.ToString());
            foreach (dynamic usuario in listUsuarios)
            {
                Administrador unAdministrador = new Administrador(usuario.id, usuario.nombre, usuario.password, usuario.nombre, usuario.apellido, usuario.domicilio, usuario.fechaDeAlta);
                listadoAdministradores.Add(unAdministrador);
            }
            rd.Close();
            return listadoAdministradores;
        }
    }
}