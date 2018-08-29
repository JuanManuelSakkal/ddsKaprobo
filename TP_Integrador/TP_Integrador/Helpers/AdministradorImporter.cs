using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TP_Integrador.Clases;

namespace TP_Integrador.Helpers
{
    public static class AdministradorImporter
    {
        private static string path = (@"/json/Administradores.json");
        private static JsonAdapter json = new JsonAdapter(path);

        public static List<Administrador> ImportarUsuarios()
        {
            List<Administrador> listadoAdministradores = new List<Administrador>();

            List<Administrador> listUsuarios = JsonConvert.DeserializeObject<List<Administrador>>(json.ReadAll());
            System.Diagnostics.Debug.WriteLine(json.ReadAll());
            foreach (Administrador usuario in listUsuarios)
            {
                Administrador unAdministrador = new Administrador(usuario.idUsuario, usuario.nombre, usuario.password, usuario.nombre, usuario.apellido, usuario.domicilio, usuario.fechaDeAlta);

                listadoAdministradores.Add(unAdministrador);
            }

            return listadoAdministradores;
        }
    }
}