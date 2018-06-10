using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public abstract class EstadoDispositivo
    {
       abstract public bool EstaEncendido();

       abstract public bool EstaApagado();

    }
}