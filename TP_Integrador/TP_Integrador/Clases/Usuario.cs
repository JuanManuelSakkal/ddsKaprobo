using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador.Clases
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Domicilio { get; set; }
        public DateTime FechaDeAlta { get; set; }

        public Usuario()
        {

        }

        public Usuario(int unId, string unNombreUsuario, string unPassword, string unNombre, string unApellido, string unDomicilio)
        {
            UsuarioID = unId;
            NombreUsuario = unNombreUsuario;
            Password = unPassword;
            Nombre = unNombre;
            Apellido = unApellido;
            Domicilio = unDomicilio;
            FechaDeAlta = DateTime.Now;
        }

        public Usuario(int unId, string unNombreUsuario, string unPassword, string unNombre, string unApellido, string unDomicilio, DateTime fechaAlta)
        {
            UsuarioID = unId;
            NombreUsuario = unNombreUsuario;
            Password = unPassword;
            Nombre = unNombre;
            Apellido = unApellido;
            Domicilio = unDomicilio;
            FechaDeAlta = fechaAlta;
        }
    }

   
}