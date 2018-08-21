using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace TP_Integrador.Clases
{
    public class CategoriaHandler
    {
        // Se instancia en Global.asax.cs

        private static CategoriaHandler instance;
        private DataTable categorias;

        private CategoriaHandler()
        {
            categorias = GetTable();
            
        }
    
        public static CategoriaHandler getInstance()
        {
            if (instance == null)
            {
                instance = new CategoriaHandler();
            }
            return instance;
        }

        static DataTable GetTable()
        {
            // Luego en una BBDD
            DataTable table = new DataTable();
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("ValorMinimo", typeof(int));
            table.Columns.Add("ValorMaximo", typeof(int));
            table.Columns.Add("CargoFijo", typeof(float));
            table.Columns.Add("CargoVariable", typeof(float));

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

        public int getCargoFijoPorCategoria(string categoria)
        {
            string expresion = "Nombre = " + categoria;

            DataRow[] rows = categorias.Select(expresion);

            foreach (DataRow row in rows)
                {
                    return (int)row["CargoFijo"];
                }

            return 0; // Si la lista no tiene Rows
        }

        public int getCargoVariablePorCategoria(string categoria)
        {
            string expresion = "Nombre = " + categoria;

            DataRow[] rows = categorias.Select(expresion);

            foreach (DataRow row in rows)
            {
                return (int)row["CargoVariable"];
            }

            return 0; // Si la lista no tiene Rows
        }

       /* public Categoria recategorizar(int consumo)
        {
            
        }
        */
    }
}