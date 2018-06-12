using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class DispositivoInteligente : Dispositivo
    {
        public bool esAdaptado { get; set; }
        public EstadoDispositivo modo { get; set;}
        public Fabricante interfaz { get; set; }
        public TimeSpan HorasPrendido { get => HorasPrendido; set => HorasPrendido = value; }
        public DateTime HoraPrendido;

        public DispositivoInteligente(string unNombreDispositivo, int unKwPorHora, bool adaptado, Fabricante unaInterfaz) : base(unNombreDispositivo, unKwPorHora)
        {
            modo = new Apagado();
            esAdaptado = adaptado;
            interfaz = unaInterfaz;
            HorasPrendido = new TimeSpan(0,0,0);
        }

        public bool EstaEncendido()
        {
            return modo.EstaEncendido();
        }

        public bool EstaApagado()
        {
            return modo.EstaApagado();
        }

        public bool EstaEnModoAhorro() // Duda
        {
            return modo.GetType().Equals(typeof(AhorroEnergia));
        }

        public bool Encender()
        {
            if(modo.GetType() != typeof(Encendido))
            {
                modo = new Encendido();
                HoraPrendido = DateTime.Now;
            }

            return true;
        }

        public bool Apagar()
        {
            if(modo.GetType() != typeof(Apagado))
            {
                modo = new Apagado();
                // Voy acumulando un TimeSpan para cuando se realice el calculo de consumo
                HorasPrendido += (DateTime.Now.TimeOfDay - HoraPrendido.TimeOfDay);
            }

            return true;
        }

        public bool PasarAAhorroDeEnergia()
        {
            modo = new AhorroEnergia();
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