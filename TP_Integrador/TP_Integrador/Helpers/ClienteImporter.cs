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

            var listUsuarios = JsonConvert.DeserializeObject<List<Cliente>>(rd.ToString());
            foreach (dynamic usuario in listUsuarios)
            {
                // Importar y crear Categoria
                // Importar y crear la listaDeDispositivos
                Cliente unCliente = new Cliente(usuario.id, usuario.usuario, usuario.password, usuario.nombre, usuario.apellido, usuario.domicilio, usuario.fechaDeAlta, usuario.tipoDoc, usuario.numDoc, usuario.tel, /* creado anteriormente categoria*/, /*List < Dispositivo > unosDisp*/);
                listadoClientes.Add(unCliente);
            }

            return JsonConvert.DeserializeObject<List<Cliente>>(File.ReadAllText(path));
        }
    }
}