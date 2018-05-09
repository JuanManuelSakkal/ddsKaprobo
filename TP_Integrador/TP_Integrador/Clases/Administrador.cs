using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class Administrador : Usuario
    {

        public int tiempoComoAdmin()
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan tiempoTranscurrido = fechaActual - this.fechaDeAlta;
            int meses = tiempoTranscurrido.Days / 30;
            return meses;
        }
    }
}