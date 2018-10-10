using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador.Clases
{
    public class DispositivoInteligente : Dispositivo
    {
        public bool EsAdaptado { get; set; }
        public int ModoID { get; set;}
        public int InterfazID { get; set; }
        //public TimeSpan HorasPrendido { get => HorasPrendido; set => HorasPrendido = value; }
        public DateTime HoraPrendido;

        [ForeignKey("ModoID")]
        public EstadoDispositivo Modo { get; set; }

        [ForeignKey("InterfazID")]
        public Fabricante Interfaz { get; set; }

        public DispositivoInteligente(string unNombreDispositivo, double unKwPorHora, Fabricante unaInterfaz) : base(unNombreDispositivo, unKwPorHora)
        {
            Modo = new Apagado();
            //esAdaptado = adaptado;
            Interfaz = unaInterfaz;
            //HorasPrendido = new TimeSpan(0,0,0);
        }

        //public void AdaptarDispositivo

        //public DispositivoInteligenteAdaptado public DispositivoInteligente(string unNombreDispositivo, int unKwPorHora, bool adaptado, Fabricante unaInterfaz) : base(unNombreDispositivo, unKwPorHora)

        public bool EstaEncendido()
        {
            return Modo.EstaEncendido();
        }

        public bool EstaApagado()
        {
            return Modo.EstaApagado();
        }

        public bool EstaEnModoAhorro() // Duda
        {
            return Modo.GetType().Equals(typeof(AhorroEnergia));
        }

        public bool Encender()
        {
            if(Modo.GetType() != typeof(Encendido))
            {
                Modo = new Encendido();
                HoraPrendido = DateTime.Now;
            }

            return true;
        }

        public bool Apagar()
        {
            if(Modo.GetType() != typeof(Apagado))
            {
                Modo = new Apagado();
                // Voy acumulando un TimeSpan para cuando se realice el calculo de consumo
                //HorasPrendido += (DateTime.Now.TimeOfDay - HoraPrendido.TimeOfDay);
            }

            return true;
        }

        public bool PasarAAhorroDeEnergia()
        {
            Modo = new AhorroEnergia();
            //bool respuesta = modo.correr o algo asi
            return true;
        }

        public float EnergiaConsumidaEnUltimasHs(int horas)
        {
            return 0;
        }

        public float EnergiaConsumidaEnPeriodo(int periodo)
        {
            return 0;
        }
    }
}