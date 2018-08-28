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
        private static string path = (@"/json/Clientes.json");
        private static JsonAdapter json = new JsonAdapter(path);

        public static List<Cliente> ImportarUsuarios()
        {
            List<Cliente> listClientes = JsonConvert.DeserializeObject<List<Cliente>>(json.ReadAll());
            return listClientes;
        }
    }
}