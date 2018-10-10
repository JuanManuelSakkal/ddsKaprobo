using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador.Clases
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaID { get; set; }

        public string Nombre { get; set; }
        public double CargoFijo { get; set; }
        public double CargoVariable { get; set; }

        public Categoria()
        {

        }

        public Categoria(string idCate)
        {
            // Suponiendo que cuando se instancia un nuevo cliente, con su categoria, arranca en R1

            Nombre = idCate;
            CargoFijo = CategoriaHandler.GetCargoFijoPorCategoria(Nombre);
            CargoVariable = CategoriaHandler.GetCargoVariablePorCategoria(Nombre);
        }

        [JsonConstructor]
        public Categoria(string idCate, double unCargoFijo, double unCargoVariable)
        {
            Nombre = idCate;
            CargoFijo = unCargoFijo;
            CargoVariable = unCargoVariable;
        }

    }
}