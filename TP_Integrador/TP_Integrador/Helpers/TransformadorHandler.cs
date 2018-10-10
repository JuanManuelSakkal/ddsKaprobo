using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Integrador.Clases;
using TP_Integrador.Data;

namespace TP_Integrador.Helpers
{
    public static class TransformadorHandler
    {
        private static List<Transformador> transformadores = new List<Transformador>();

        public static List<Transformador> GetTransformadores()
        {
            using (var db = new ContextoDB())
            {
                var query = from t in db.Transformadores
                            select t;
                foreach (var transformador in query)
                {
                    transformadores.Add(transformador);
                }
            }
            return transformadores;
        }

        public static List<Transformador> GetTransformadorByTransformadorID(int transformadorID)
        {
            using (var db = new ContextoDB())
            {
                var query = from t in db.Transformadores
                            select t;
                foreach (var transformador in query)
                {
                    if (transformador.TransformadorID == transformadorID)
                    {
                        transformadores.Add(transformador);
                    }
                }
            }
            return transformadores;
        }
    }
}