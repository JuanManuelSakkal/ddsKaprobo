using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TP_Integrador.Helpers;

namespace TP_Integrador.Clases
{
    public abstract class EstadoDispositivo
    {
        private Logger Log;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstadoDispositivoID { get; set; }

        public void Encender(DispositivoInteligente dispositivo)
        {
            if (dispositivo.Modo.GetType() != typeof(Encendido))
            {
                dispositivo.Modo = new Encendido();
                Log.Log("Se ha encendido el dispositivo: " + dispositivo.NombreDispositivo);
            }
        }

        public void Apagar(DispositivoInteligente dispositivo)
        {
            if (dispositivo.Modo.GetType() != typeof(Apagado))
            {
                dispositivo.Modo = new Apagado();
                Log.Log("Se ha apagado el dispositivo: " + dispositivo.NombreDispositivo);
            }
        }

        public void PasarAModoAhorro(DispositivoInteligente dispositivo)
        {
            if (dispositivo.Modo.GetType() != typeof(AhorroEnergia))
            {
                dispositivo.Modo = new AhorroEnergia();
                Log.Log("Se ha pasado a modo ahorro al dispositivo: " + dispositivo.NombreDispositivo);
            }
        }

        abstract public bool EstaEncendido();

        abstract public bool EstaApagado();

    }
}