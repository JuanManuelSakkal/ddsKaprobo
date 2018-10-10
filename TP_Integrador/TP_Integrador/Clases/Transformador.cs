using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador.Clases
{
    public class Transformador
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransformadorID { get; set; }
        public string Domicilio { get; set; }
        public List<Cliente> Clientes;

        public Transformador(string unDomicilio)
        {
            Domicilio = unDomicilio;
            Clientes = new List<Cliente>();
        }

        public int EnergiaSuministrada()
        {
            int energiaSuministrada = 0;

            foreach (var cliente in Clientes)
            {
                // energiaSuministrada = cliente.EnergiaConsumidaPorDispositivos();
            }

            return energiaSuministrada;
        }
    }
}