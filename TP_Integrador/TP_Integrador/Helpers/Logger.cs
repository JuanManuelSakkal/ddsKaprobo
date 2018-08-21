using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TP_Integrador.Helpers
{
    public class Logger
    {
        string path;
        HttpServerUtility server = HttpContext.Current.Server;
        StreamWriter logger;

        public Logger()
        {
            logger = File.AppendText("C:/Users/agnme/ddsKaprobo/TP_Integrador/TP_Integrador/logger.txt");
        }

        public Logger(string locationString)
        {
            path = server.MapPath(@locationString);
           // logger = File.AppendText("logger.txt");
        }

        public void Log(string eventToLog)
        {
            StreamWriter wr = new StreamWriter(path,true);
            JObject jsonObject = new JObject();
            jsonObject.Add("TimeStamp", DateTime.Now);
            jsonObject.Add("Event", eventToLog);
            using (JsonTextWriter writer = new JsonTextWriter(wr))
            {
                jsonObject.WriteTo(writer);
            }
            wr.Close();
        }

        // Para loguear las operaciones
        public void LogMessage(string mensaje/*, TextWriter writer*/)
        {
            logger.Write("\r\n {0} {1} : {2} ", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), mensaje);
        }
    }
}