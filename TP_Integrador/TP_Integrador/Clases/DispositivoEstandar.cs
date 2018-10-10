using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class DispositivoEstandar : Dispositivo
    {
        public float HorasUso;

        public DispositivoEstandar()
        {

        }

        public DispositivoEstandar(string unNombreDispositivo, double unKwPorHora) : base(unNombreDispositivo, unKwPorHora)
        {

        }
        public void SetHorasUso(int horas) => HorasUso = horas;

    }
}