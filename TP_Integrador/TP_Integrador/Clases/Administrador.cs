using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TP_Integrador.Clases
{
    public class Administrador : Usuario
    {   
        // Constructor para la creación de un usuario en tiempo de ejecución (Se automatiza la fecha de alta -actual-)
        public Administrador(int unId, string unNombreUsuario, string unPassword, string unNombre,
            string unApellido, string unDomicilio) : base(unId, unNombreUsuario, unPassword, unNombre,
            unApellido, unDomicilio)
        {

        }

        // Constructor para el importerAdministrador
        [JsonConstructor]
        public Administrador(int unId, string unNombreUsuario, string unPassword, string unNombre,
            string unApellido, string unDomicilio, DateTime fechaDeAlta) : base(unId, unNombreUsuario, unPassword, unNombre,
            unApellido, unDomicilio, fechaDeAlta)
        {

        }

        public int TiempoComoAdmin()
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan tiempoTranscurrido = fechaActual - this.FechaDeAlta;
            int meses = tiempoTranscurrido.Days / 30;
            return meses;
        }
    }
}