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
    public static class ClienteImporter
    {
        
        static HttpServerUtility server = HttpContext.Current.Server;
        static string path = server.MapPath(@"~/json/Clientes.json");

        public static List<Cliente> ImportarUsuarios()
        {
            StreamReader rd = new StreamReader(path);
            List<Cliente> listadoClientes = new List<Cliente>();
            
            var listUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(rd.ReadToEnd());
            foreach (dynamic usuario in listUsuarios)
            {
                Cliente unCliente = new Cliente(usuario.id, usuario.usuario,usuario.password, usuario.nombre,usuario.apellido,usuario.domicilio,usuario.fechaDeAlta,usuario.tipoDoc,usuario.numDoc,usuario.tel,new Categoria(1,1),new List<Dispositivo>());
                listadoClientes.Add(unCliente);
            }
            rd.Close();
            return listadoClientes;
        }
    }
}