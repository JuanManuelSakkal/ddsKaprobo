using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class Regla : SubjectObserverRegla
    {
        private bool seCumple;

        public bool SeCumple()
        {
            return seCumple;
        }

        public void SeCumple(bool valor)
        {
            seCumple = valor;
        }
    }
}