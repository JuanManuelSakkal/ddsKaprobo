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

        public DispositivoEstandar(string unNombreDispositivo, double unKwPorHora, Cliente duenio) : base(unNombreDispositivo, unKwPorHora, duenio)
        {

        }

        public double CalcularConsumoMensual(int periodo)
        {
            return KwPorHora * 30;
        }
        public void SetHorasUso(int horas) => HorasUso = horas;

    }
}