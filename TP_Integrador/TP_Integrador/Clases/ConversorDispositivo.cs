using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class ConversorDispositivo //Singleton
    {
        private static ConversorDispositivo instance;

        public static ConversorDispositivo GetInstance()
        {
            if (instance == null)
            {
                instance = new ConversorDispositivo();
            }
            return instance;
        }

        public void Convertir(DispositivoEstandar unDispositivo, Cliente unCliente)
        {
            DispositivoInteligente dispositivoInteligente = new DispositivoInteligente(unDispositivo.NombreDispositivo, unDispositivo.KwPorHora, new FabricanteDePrueba());
            unCliente.Dispositivos.Remove(unDispositivo);
            unCliente.Dispositivos.Add(dispositivoInteligente);

            return;
        }
    }
}