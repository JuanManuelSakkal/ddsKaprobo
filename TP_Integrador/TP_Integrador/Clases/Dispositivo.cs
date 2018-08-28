using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public abstract class Dispositivo
    {
        public string nombreDispositivo{ get; set; }
        public double kwPorHora { get; set; }

        public Dispositivo(string unNombreDispositivo, double unKwPorHora)
        {
            nombreDispositivo = unNombreDispositivo;
            kwPorHora = unKwPorHora;
        }
    }
}