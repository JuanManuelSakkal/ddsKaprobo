using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TP_Integrador.Clases
{
    public class Categoria
    {
        public string idCategoria { get; set; }
        public double cargoFijo { get; set; }
        public double cargoVariable { get; set; }

        public Categoria(string idCate)
        {
            // Suponiendo que cuando se instancia un nuevo cliente, con su categoria, arranca en R1

            idCategoria = idCategoria;
            cargoFijo = CategoriaHandler.GetCargoFijoPorCategoria(idCategoria);
            cargoVariable = CategoriaHandler.GetCargoVariablePorCategoria(idCategoria);
        }

        [JsonConstructor]
        public Categoria(string idCate, double unCargoFijo, double unCargoVariable)
        {
            idCategoria = idCate;
            cargoFijo = unCargoFijo;
            cargoVariable = unCargoVariable;
        }

    }
}