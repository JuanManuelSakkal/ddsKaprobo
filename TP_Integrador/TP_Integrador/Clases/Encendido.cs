using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class Encendido : EstadoDispositivo
    {
        public override bool EstaEncendido()
        {
            return true;
        }

        public override bool EstaApagado()
        {
            return false;
        }
    }
}