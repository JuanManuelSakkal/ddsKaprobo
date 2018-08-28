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
    public class ZonaGeograficaImporter
    {

        // Obtengo la ruta fisica a partir de la ruta virtual 
        string path = HttpContext.Current.Server.MapPath(@"~/json/ZonasGeograficas.json");

        public List<ZonaGeografica> importarZonasGeograficas()
        {
            List<ZonaGeografica> listaZonas = new List<ZonaGeografica>();
            var zonasGeograficas = JsonConvert.DeserializeObject<List<ZonaGeografica>>(File.ReadAllText(path));

            foreach (dynamic zona in zonasGeograficas)
            {
                listaZonas.Add(new ZonaGeografica(zona.nombre, zona.radio));
            }

            return listaZonas;
        }

    }
}