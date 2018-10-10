﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador.Clases
{
    public abstract class Dispositivo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DispositivoID { get; set; }
        [Column("Cliente_UsuarioID")]
        public int Cliente_UsuarioID { get; set; }
        public string NombreDispositivo{ get; set; }
        public double KwPorHora { get; set; }

        public Dispositivo()
        {

        }

        public Dispositivo(string unNombreDispositivo, double unKwPorHora)
        {
            NombreDispositivo = unNombreDispositivo;
            KwPorHora = unKwPorHora;
        }
    }
}