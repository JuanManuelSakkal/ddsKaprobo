using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TP_Integrador.Clases
{
    public class UserHandler
    {

        private static UserHandler instance;
        private List<Usuario> usuarios;
        private DateTime fechaInicio { get; set; }

        private UserHandler()
        {
            usuarios = new List<Usuario>();
            fechaInicio = DateTime.Now;
        }

        public static UserHandler GetInstance()
        {
            if (instance == null)
            {
                instance = new UserHandler();
            }
            return instance;
        }

        public void agregarUsuario(Usuario usuario)
        {
            instance.usuarios.Add(usuario);
            // Se agrega a la BBDD, etc.
        }
        
        public void removerUsuario(Usuario usuario)
        {
            instance.usuarios.Remove(usuario);
            // Se saca de la BBDD, etc.
        }

        /*
            Por ahora, mantendrá la lista de Usuarios en memoria.
            Cuando veamos BBDD, se encargará de agregar, modificar, mostrar los elementos de la tabla Usuarios en la BBDD.
        */
        /*
        private void recategorizar()
        {
            List<Cliente> listaClientes = instance.getClientes();

            foreach(Usuario usuario in instance.usuarios)
            {
                usuario.g
            }
        }

        private List<Usuario> getClientes() => instance.usuarios.Where(usuario => usuario.GetType().Equals(typeof(Cliente))).ToList();
        */   
    }
}