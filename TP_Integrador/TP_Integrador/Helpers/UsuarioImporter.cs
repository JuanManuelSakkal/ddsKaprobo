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
    public class JsonImporter
    {
        string path;
        HttpServerUtility server = HttpContext.Current.Server;
        public JsonImporter(string locationString)
        {
            path = server.MapPath(@locationString);
        }

        public Dispositivo ImportarDispositivo()
        {
            StreamWriter wr = new StreamWriter(path, true);
            return new Dispositivo();
        }

        public Usuario ImportarUsuario()
        {
            StreamWriter wr = new StreamWriter(path, true);
            return new Usuario();
        }
    }
}