using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Integrador.Clases;
using Newtonsoft.Json;

namespace TP_Integrador.Helpers
{
    public class DispositivoImporter
    {
        private static string path = (@"/json/DispositivosInteligentes.json");
        private static JsonAdapter json = new JsonAdapter(path);

        public static List<DispositivoInteligente> ImportarDispositivosInteligentes()
        {
            List<DispositivoInteligente> listDispositivosInteligentes = JsonConvert.DeserializeObject<List<DispositivoInteligente>>(json.ReadAll());
            return listDispositivosInteligentes;
        }
    }
}