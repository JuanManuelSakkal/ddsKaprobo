using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class Transformador
    {
        public string domicilio { get; set; }
        public List<Usuario> usuarios;

        public Transformador(string unDomicilio)
        {
            domicilio = unDomicilio;
            usuarios = new List<Usuario>();
        }

        public int EnergiaSuministrada()
        {
            int energiaSuministrada = 0;

            foreach(var usuario in usuarios)
            {
                energiaSuministrada = usuario.EnergiaConsumidaPorDispositivos();
            }

            return energiaSuministrada;
        }
    }
}