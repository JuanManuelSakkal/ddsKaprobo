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

        public DispositivoInteligente(string unNombreDispositivo, int unKwPorHora) : base(unNombreDispositivo, unKwPorHora)
        {
            modo = new Apagado();
        }

        public bool EstaEncendido()
        {
            return modo.GetType().Equals(typeof(Encendido));
        }

        public bool EstaApagado()
        {
            return modo.GetType().Equals(typeof(Apagado));
        }

        public bool Encender()
        {
            modo = new Encendido();
            //bool respuesta = modo.correr o algo asi
            return true;
        }

        public bool Apagar()
        {
            modo = new Apagado();
            //bool respuesta = modo.correr o algo asi
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