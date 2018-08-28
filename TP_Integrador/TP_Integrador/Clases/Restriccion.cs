using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class Restriccion
    {
        public double valorAComparar;
        public List<double> valoresDeLosDispositivos;
        public string operador;

        public Restriccion(double vAC, List<double> vDLD, string op)
        {
            valorAComparar = vAC;
            valoresDeLosDispositivos = vDLD;
            operador = op;
        }
    }
}