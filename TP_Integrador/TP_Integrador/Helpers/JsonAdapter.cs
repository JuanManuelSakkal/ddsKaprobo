using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TP_Integrador.Helpers
{
    public class JsonAdapter
    {
        HttpServerUtility server = HttpContext.Current.Server;
        private string path;

        private int contadorSimplex = 0;
        //Unicamente para Simplex
        public JsonAdapter()
        {
            
        }

        public JsonAdapter(string jsonPath)
        {
            path = server.MapPath(@jsonPath);
        }

        public string ReadAll()
        {
            return System.IO.File.ReadAllText(path);            
        }
    }
}