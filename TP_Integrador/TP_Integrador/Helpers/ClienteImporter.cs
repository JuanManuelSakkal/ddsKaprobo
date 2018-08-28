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
    public static class ClienteImporter
    {
        private static string path = (@"/json/Clientes.json");
        private static JsonAdapter json = new JsonAdapter(path);

        public static List<Cliente> ImportarUsuarios()
        {
<<<<<<< HEAD
            List<Cliente> listClientes = JsonConvert.DeserializeObject<List<Cliente>>(json.ReadAll());
            return listClientes;
=======
            StreamReader rd = new StreamReader(path);
            List<Cliente> listadoClientes = new List<Cliente>();
            List<Dispositivo> listadoDispositivos = new List<Dispositivo>();

            var listUsuarios = JsonConvert.DeserializeObject<List<Cliente>>(rd.ToString());
            foreach (dynamic usuario in listUsuarios)
            {
                // Importar y crear Categoria
                var category = JsonConvert.DeserializeObject<Categoria>(usuario.categoria);
                Categoria unaCategoria = new Categoria(category.idCategoria, category.cargoFijo, category.cargoVariable);
                // Importar y crear la listaDeDispositivos
                var dispositivos = JsonConvert.DeserializeObject<List<Dispositivo>>(usuario.dispositivos);

                foreach (dynamic dispositivo in dispositivos)
                {
                    listadoDispositivos.Add(new Dispositivo(dispositivo.nombre, dispositivo.kw));
                }

                Cliente unCliente = new Cliente(usuario.id, usuario.usuario, usuario.password, usuario.nombre, usuario.apellido, usuario.domicilio, usuario.fechaDeAlta, usuario.tipoDoc, usuario.numDoc, usuario.tel, unaCategoria/*, List < Dispositivo > unosDisp*/);
                listadoClientes.Add(unCliente);
            }

            return JsonConvert.DeserializeObject<List<Cliente>>(File.ReadAllText(path));
>>>>>>> 400ca494c6f411ef5a34be962b3ecdfdd1c1a637
        }
    }
}