using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class Transformador
    {
        public int id;
        public string domicilio { get; set; }
        public List<Cliente> clientes;

        public Transformador(int unId, string unDomicilio)
        {
            id = unId;
            domicilio = unDomicilio;
            clientes = new List<Cliente>();
        }

        public int EnergiaSuministrada()
        {
            int energiaSuministrada = 0;

            foreach (var cliente in clientes)
            {
                // energiaSuministrada = cliente.EnergiaConsumidaPorDispositivos();
            }

            return energiaSuministrada;
        }
    }
}