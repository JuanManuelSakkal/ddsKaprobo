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

        public DispositivoInteligente()
        {

        }

        public DispositivoInteligente(string unNombreDispositivo, double unKwPorHora, Cliente duenio, Fabricante unaInterfaz) : base(unNombreDispositivo, unKwPorHora, duenio)
        {
            Modo = new Apagado();
            //esAdaptado = adaptado;
            Interfaz = unaInterfaz;
            //HorasPrendido = new TimeSpan(0,0,0);
        }

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

        public void Encender()
        {
            Modo.Encender(this);
            HoraPrendido = DateTime.Now;
        }

        public void Apagar()
        {
            Modo.Apagar(this);
            HoraPrendido = DateTime.MinValue;
        }

        public void PasarAAhorroDeEnergia()
        {
            Modo.PasarAModoAhorro(this);
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