using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Integrador.Helpers;

namespace TP_Integrador.Clases
{
    public class ConversorDispositivo //Singleton
    {
        private static ConversorDispositivo instance;
        private static Logger log;

        public static ConversorDispositivo GetInstance()
        {
            if (instance == null)
            {
                instance = new ConversorDispositivo();
            }
            return instance;
        }

        public void Convertir(DispositivoEstandar unDispositivo, Cliente unCliente, Fabricante unFabricante)
        {
            DispositivoInteligente dispositivoInteligente = new DispositivoInteligente(unDispositivo.NombreDispositivo, unDispositivo.KwPorHora, unFabricante);
            dispositivoInteligente.EsAdaptado = true;
            unCliente.Dispositivos.Remove(unDispositivo);
            unCliente.Dispositivos.Add(dispositivoInteligente);

            log.Log("El cliente: " + unCliente.Apellido + " " + unCliente.Nombre + " ha convertido el dispositivo estandar" + unDispositivo.NombreDispositivo + " en un dispositivo inteligente adaptado.");
            return;
        }

        public void RemoverAdaptador(DispositivoInteligente unDispositivo, Cliente unCliente)
        {
            DispositivoEstandar de = new DispositivoEstandar(unDispositivo.NombreDispositivo, unDispositivo.KwPorHora);
            unCliente.Dispositivos.Remove(unDispositivo);
            unCliente.Dispositivos.Add(de);

            log.Log("El cliente: " + unCliente.Apellido + " " + unCliente.Nombre + " ha removido el adaptadaor del dispositivo " + unDispositivo.NombreDispositivo + ", convirtiendolo nuevamente en Dispositivo Estandar.");
            return;
        }
    }
}