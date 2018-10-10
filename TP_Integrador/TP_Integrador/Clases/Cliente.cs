using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TP_Integrador.Clases
{
    public class Cliente : Usuario
    {
        public string TipoDoc { get; set; }
        public string NumeroDoc { get; set; }
        public string Telefono { get; set; }
        public int CategoriaID { get; set; }        
        public int Puntos { get; set; }
        public List<Dispositivo> Dispositivos { get; set; }

        [ForeignKey("CategoriaID")]
        public Categoria Categoria { get; set; }

        public Cliente()
        {
            Dispositivos = new List<Dispositivo>();
        }

        // Constructor para cuando se crea un nuevo cliente. Paso como parámetro categoriaHandler para que, cuando se instancia una categoria, éste le pase los valores correspondientes.
        public Cliente(int unId, string unNombreUsuario, string unPassword, string unNombre, string unApellido, string unDomicilio, string unTD, string unND, string unTel/*, CategoriaHandler categoriaHandler*/) : base(unId, unNombreUsuario, unPassword, unNombre, unApellido, unDomicilio)
        {
            TipoDoc = unTD;
            NumeroDoc = unND;
            Telefono = unTel;
            Puntos = 0;
            //categoria = new Categoria(categoriaHandler);
        }

        // Constructor para el ClienteImporter
        public Cliente(int unId, string unNombreUsuario, string unPassword, string unNombre, string unApellido, string unDomicilio, DateTime fechaDeAlta,
            string unTD, string unND, string unTel, string idCategoria /*, List<Dispositivo> unosDisp*/) : base(unId, unNombreUsuario, unPassword, unNombre,
            unApellido, unDomicilio, fechaDeAlta)
        {
            TipoDoc = unTD;
            NumeroDoc = unND;
            Telefono = unTel;
            Puntos = 0;
            Categoria = CategoriaHandler.GetCategoria(idCategoria);
           // dispositivos = unosDisp;
        }
        

        public int CantidadDispositivos()
        {
            return this.Dispositivos.Count();
        }
        
        public bool HayDispositivoEncendido()
        {
            bool hayEncendido = false;
            int cantDisp = this.CantidadDispositivos();
            for (int i = 0; i < cantDisp; i++)
            {
                if (Dispositivos[i].GetType().Equals(typeof(DispositivoInteligente)))
                {
                    if (((DispositivoInteligente)Dispositivos[i]).EstaEncendido())
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
                if (Dispositivos[i].GetType().Equals(typeof(DispositivoInteligente)))
                {
                    if (((DispositivoInteligente)Dispositivos[i]).EstaEncendido())
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
                if (Dispositivos[i].GetType().Equals(typeof(DispositivoInteligente)))
                {
                    if (((DispositivoInteligente)Dispositivos[i]).EstaApagado())
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
            Dispositivos.Add(new DispositivoEstandar(unNombreDispositivo, unKwPorHora));
        }

        public double EnergiaConsumidaPorDispositivos()
        {
            double energia = 0;

            foreach(var dispositivo in Dispositivos)
            {
                energia += dispositivo.KwPorHora;
            }

            return energia;
        }
        /*
        public void AgregarDispositivoInteligente()
        {
            Dispositivos.Add(new DispositivoInteligente(string unNombreDispositivo, int unKwPorHora));

        }
        */
        // public void AdaptarDispositivoEstandar

        /* public void Recategorizar()
         {
             Categoria = CategoriaHandler.recategorizar(consumo); // int consumo. Recategorizar devuelve la instancia de una nueva categoria
         }
         */
    }
}