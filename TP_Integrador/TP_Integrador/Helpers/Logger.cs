using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TP_Integrador.Helpers;

namespace TP_Integrador.Helpers
{
    public class Logger
    {
        string path;
        HttpServerUtility server = HttpContext.Current.Server;
        StreamWriter logger;

        public Logger()
        {
            logger = File.AppendText("C:/Users/sebik/Desktop/UTN/3er Año/Diseño de Sistemas/2018/TPs/ddsKaprobo/TP_Integrador/TP_Integrador/logger.txt");
        }

        public Logger(string locationString)
        {
            path = locationString;
           // logger = File.AppendText("logger.txt");
        }

        public void Log(string eventToLog)
        {
            //JsonAdapter json = new JsonAdapter(path, false);
            //json.Write(eventToLog);
        }

        // Para loguear las operaciones
        public void LogMessage(string mensaje/*, TextWriter writer*/)
        {
            logger.Write("\r\n {0} {1} : {2} ", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), mensaje);
        }
    }
}