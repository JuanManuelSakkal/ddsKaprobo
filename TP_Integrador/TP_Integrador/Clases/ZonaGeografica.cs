using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador.Clases
{
    public class ZonaGeografica
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZonaGeograficaID { get; set; }
        private string NombreZona;
        private int Radio;
        public List<Transformador> Transformadores;


        public ZonaGeografica(string unNombre, int unRadio)
        {
            NombreZona = unNombre;
            Radio = unRadio;
            Transformadores = new List<Transformador>();
        }

        public int ConsumoTotal()
        {
            int consumo = 0;

            foreach (var transformador in Transformadores)
            {
                consumo += transformador.EnergiaSuministrada();
            }

            return consumo;
        }
    }
}