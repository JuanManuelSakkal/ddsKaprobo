using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class Administrador : Usuario
    {
        public Administrador(int unId, string unNombreUsuario, string unPassword, string unNombre,
            string unApellido, string unDomicilio, DateTime unaFechaDeAlta) : base(unId, unNombreUsuario, unPassword, unNombre,
            unApellido, unDomicilio, unaFechaDeAlta)
        {

        }

        public int TiempoComoAdmin()
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan tiempoTranscurrido = fechaActual - this.fechaDeAlta;
            int meses = tiempoTranscurrido.Days / 30;
            return meses;
        }
    }
}