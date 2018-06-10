using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class AhorroEnergia : EstadoDispositivo
    {
        public override bool EstaEncendido()
        {
            return false;
        }

        public override bool EstaApagado()
        {
            return false;
        }


    }
}