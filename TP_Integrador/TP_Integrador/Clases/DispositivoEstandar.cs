using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class DispositivoEstandar : Dispositivo
    {
        public float HorasUso;

        public DispositivoEstandar(string unNombreDispositivo, int unKwPorHora) : base(unNombreDispositivo, unKwPorHora)
        {

        }
        public void SetHorasUso(int horas) => HorasUso = horas;

    }
}