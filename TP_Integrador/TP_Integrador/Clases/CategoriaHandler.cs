using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace TP_Integrador.Clases
{
    public static class CategoriaHandler
    {
        // Se instancia en Global.asax.cs
        
        //private static DataTable categorias;
        private static List<Categoria> categorias = new List<Categoria>();

        public static List<Categoria> GetCategorias()
        {
            Categoria R1 = new Categoria("R1", 18.76, 0.644);
            Categoria R2 = new Categoria("R2", 35.32, 0.644);
            Categoria R3 = new Categoria("R3", 60.71, 0.681);
            Categoria R4 = new Categoria("R4", 71.74, 0.738);
            Categoria R5 = new Categoria("R5", 110.38, 0.794);
            Categoria R6 = new Categoria("R6", 220.75, 0.832);
            Categoria R7 = new Categoria("R7", 443.59, 0.851);
            Categoria R8 = new Categoria("R8", 545.96, 0.851);
            Categoria R9 = new Categoria("R9", 887.19, 0.851);

            categorias.Add(R1);
            categorias.Add(R2);
            categorias.Add(R3);
            categorias.Add(R4);
            categorias.Add(R5);
            categorias.Add(R6);
            categorias.Add(R7);
            categorias.Add(R8);
            categorias.Add(R9);

            return categorias;
        }

        public static Categoria GetCategoria(string categoria)
        {
            foreach (Categoria cat in GetCategorias())
            {
                if (cat.idCategoria == categoria)
                {
                    return cat;
                }
            }
            return null;
        }

        public static DataTable GetTable()
        {
            // Luego en una BD
            DataTable table = new DataTable();
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("ValorMinimo", typeof(int));
            table.Columns.Add("ValorMaximo", typeof(int));
            table.Columns.Add("CargoFijo", typeof(float));
            table.Columns.Add("CargoVariable", typeof(float));

            //DataSet ds = new DataSet();
            //ds.L

            table.Rows.Add("R1", 0, 150, 18.76,0.644);
            table.Rows.Add("R2", 150, 325,35.32, 0.644);
            table.Rows.Add("R3", 325, 400,60.71, 0.681);
            table.Rows.Add("R4", 400, 450, 71.74, 0.738);
            table.Rows.Add("R5", 450, 500, 110.38, 0.794);
            table.Rows.Add("R6", 500, 600, 220.75, 0.832);
            table.Rows.Add("R7", 600, 700, 443.59, 0.851);
            table.Rows.Add("R8", 700, 1400, 545.96, 0.851);
            table.Rows.Add("R9", 1400, 9999, 887.19, 0.851);

            return table;
        }

        public static double GetCargoFijoPorCategoria(string categoria)
        {
            /*string expresion = "Nombre = " + categoria;

            DataRow[] rows = categorias.Select(expresion);

            foreach (DataRow row in rows)
            {
                return (int)row["CargoFijo"];
            }

            return 0; // Si la lista no tiene Rows*/

            return GetCategoria(categoria).cargoFijo;
        }

        public static double GetCargoVariablePorCategoria(string categoria)
        {
            /*string expresion = "Nombre = " + categoria;

            DataRow[] rows = categorias.Select(expresion);

            foreach (DataRow row in rows)
            {
                return (int)row["CargoVariable"];
            }

            return 0; // Si la lista no tiene Rows*/
            return GetCategoria(categoria).cargoVariable;
        }

       /* public Categoria recategorizar(int consumo)
        {
            
        }
        */
    }
}