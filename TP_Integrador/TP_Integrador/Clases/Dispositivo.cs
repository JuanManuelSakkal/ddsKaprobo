﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class Dispositivo
    {
        public string nombreDispositivo{ get; set; }
        public int kwPorHora { get; set; }

        public Dispositivo(string unNombreDispositivo, int unKwPorHora)
        {
            nombreDispositivo = unNombreDispositivo;
            kwPorHora = unKwPorHora;
        }
    }
}