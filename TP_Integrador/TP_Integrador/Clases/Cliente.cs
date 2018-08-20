﻿using System;
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
        public int puntos { get; set; }
        public List<Dispositivo> dispositivos { get; set; }        

        public Cliente(int unId, string unNombreUsuario, string unPassword, string unNombre, string unApellido, string unDomicilio, 
            string unTD, string unND, string unTel, CategoriaHandler categoriaHandler, List<Dispositivo> unosDisp) : base(unId, unNombreUsuario, unPassword, unNombre,
            unApellido, unDomicilio)
        {
            tipoDoc = unTD;
            numeroDoc = unND;
            telefono = unTel;
            puntos = 0;
            categoria = new Categoria(categoriaHandler);
            dispositivos = unosDisp;
        }
        

        public int CantidadDispositivos()
        {
            return this.dispositivos.Count();
        }
        
        public bool HayDispositivoEncendido()
        {
            bool hayEncendido = false;
            int cantDisp = this.CantidadDispositivos();
            for (int i = 0; i < cantDisp; i++)
            {
                if (dispositivos[i].GetType().Equals(typeof(DispositivoInteligente)))
                {
                    if (((DispositivoInteligente)dispositivos[i]).EstaEncendido())
                    {
                        hayEncendido = true;
                        break;
                    }
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
                if (dispositivos[i].GetType().Equals(typeof(DispositivoInteligente)))
                {
                    if (((DispositivoInteligente)dispositivos[i]).EstaEncendido())
                    {
                        cantEncendidos++;

                    }
                }              
            }

            return cantEncendidos;
        }

        public int DispositivosApagados()
        {
            int cantApagados = 0;
            int cantDisp = this.CantidadDispositivos();
            for (int i = 0; i < cantDisp; i++)
            {
                if (dispositivos[i].GetType().Equals(typeof(DispositivoInteligente)))
                {
                    if (((DispositivoInteligente)dispositivos[i]).EstaApagado())
                    {
                        cantApagados++;

                    }
                }
            }

            return cantApagados;
        }

        public void SetHorasUso(DispositivoEstandar unDispositivo, int horas)
        {
            unDispositivo.SetHorasUso(horas);
        }

        public void AgregarDispositivoEstandar(string unNombreDispositivo, int unKwPorHora)
        {
            dispositivos.Add(new DispositivoEstandar(unNombreDispositivo, unKwPorHora));
        }
        /*
        public void AgregarDispositivoInteligente()
        {
            dispositivos.Add(new DispositivoInteligente(string unNombreDispositivo, int unKwPorHora));

        }
        */
        // public void AdaptarDispositivoEstandar

       // public void Recategorizar()

    }
}