using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class ZonaGeografica
    {
        private string nombreZona;
        private int radio;
        public List<Transformador> transformadores;


        public ZonaGeografica(string unNombre, int unRadio)
        {
            nombreZona = unNombre;
            radio = unRadio;
            transformadores = new List<Transformador>();
        }

        public int ConsumoTotal()
        {
            int consumo = 0;

            foreach (var transformador in transformadores)
            {
                consumo += transformador.EnergiaSuministrada();
            }

            return consumo;
        }
    }
}