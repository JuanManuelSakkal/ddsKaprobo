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
            return JsonConvert.DeserializeObject<List<Cliente>>(File.ReadAllText(path));
        }
    }
}