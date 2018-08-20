using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class Categoria
    {
        string categoria { get; set; }
        public float cargoFijo { get; set; }
        public float cargoVariable { get; set; }
        private CategoriaHandler categoryHandler;

        public Categoria(CategoriaHandler categoriaHandler)
        {
            // Suponiendo que cuando se instancia un nuevo cliente, con su categoria, arranca en R1

            categoria = "R1";
            cargoFijo = categoriaHandler.getCargoFijoPorCategoria(categoria);
            cargoVariable = categoriaHandler.getCargoVariablePorCategoria(categoria);
            categoryHandler = categoriaHandler;
        }

    }
}