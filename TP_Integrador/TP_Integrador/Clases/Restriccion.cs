using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador.Clases
{
    public class Restriccion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestriccionID { get; set; }
        public double ValorAComparar;
        public List<double> ValoresDeLosDispositivos;
        public string Operador;

        public Restriccion(double vAC, List<double> vDLD, string op)
        {
            ValorAComparar = vAC;
            ValoresDeLosDispositivos = vDLD;
            Operador = op;
        }
    }
}