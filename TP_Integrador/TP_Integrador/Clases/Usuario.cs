using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string domicilio { get; set; }
        public DateTime fechaDeAlta { get; set; }

        public Usuario(int unId, string unNombreUsuario, string unPassword, string unNombre, string unApellido, string unDomicilio)
        {
            idUsuario = unId;
            nombreUsuario = unNombreUsuario;
            password = unPassword;
            nombre = unNombre;
            apellido = unApellido;
            domicilio = unDomicilio;
            fechaDeAlta = DateTime.Now;
        }
       
    }

   
}