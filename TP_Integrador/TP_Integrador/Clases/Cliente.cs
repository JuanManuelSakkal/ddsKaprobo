using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TP_Integrador.Clases
{
    public class Cliente : Usuario

    {
        public string tipoDoc { get; set; }
        public string numeroDoc { get; set; }
        public string telefono { get; set; }
        public Categoria categoria { get; set; }
        public Dispositivo[] dispositivos { get; set; }
        

        public int CantidadDispositivos()
        {
            return this.dispositivos.Length;
        }
        
        public bool HayDispositivoEncendido()
        {
            bool hayEncendido = false;
            int cantDisp = this.CantidadDispositivos();
            for (int i = 0; i < cantDisp; i++)
            {
                if (this.dispositivos[i].encendido)
                {
                    hayEncendido = true;
                    break;
                }
            }

            return hayEncendido;
        }

        public int DispositivosEncendidos()
        {
            int cantEncendidos = 0;
            int cantDisp = this.CantidadDispositivos();
            for (int i = 0; i < cantDisp; i++)
            {
                if (this.dispositivos[i].encendido)
                {
                    cantEncendidos++;
                   
                }
            }

            return cantEncendidos;
        }

        public int DispositivosApagados()
        {
            int cantApagados = this.CantidadDispositivos() - this.DispositivosEncendidos();

            return cantApagados;
        }


    }
}