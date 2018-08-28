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
    public class TransformadorImporter
    {
        // Obtengo la ruta fisica a partir de la ruta virtual especificada
        //HttpServerUtility server = HttpContext.Current.Server;
        string path = HttpContext.Current.Server.MapPath(@"~/json/Transformadores.json");

        public TransformadorImporter() { }

        public List<Transformador> ImportarTransformadores()
        {
            List<Transformador> listaTransformadores = new List<Transformador>();
            var transformadores = JsonConvert.DeserializeObject<List<Transformador>>(File.ReadAllText(path));

            foreach (dynamic transformador in transformadores)
            {
                listaTransformadores.Add(new Transformador(transformador.id,transformador.domicilio));
            }

            return listaTransformadores;

        }
    }
}