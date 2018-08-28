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
        public int puntos { get; set; }
        public List<Dispositivo> dispositivos { get; set; }        

        public Cliente()
        {

        }

        // Constructor para cuando se crea un nuevo cliente. Paso como parámetro categoriaHandler para que, cuando se instancia una categoria, éste le pase los valores correspondientes.
        public Cliente(int unId, string unNombreUsuario, string unPassword, string unNombre, string unApellido, string unDomicilio, string unTD, string unND, string unTel/*, CategoriaHandler categoriaHandler*/) : base(unId, unNombreUsuario, unPassword, unNombre, unApellido, unDomicilio)
        {
            tipoDoc = unTD;
            numeroDoc = unND;
            telefono = unTel;
            puntos = 0;
            //categoria = new Categoria(categoriaHandler);
        }

        // Constructor para el ClienteImporter
        public Cliente(int unId, string unNombreUsuario, string unPassword, string unNombre, string unApellido, string unDomicilio, DateTime fechaDeAlta,
            string unTD, string unND, string unTel, string idCategoria /*, List<Dispositivo> unosDisp*/) : base(unId, unNombreUsuario, unPassword, unNombre,
            unApellido, unDomicilio, fechaDeAlta)
        {
            tipoDoc = unTD;
            numeroDoc = unND;
            telefono = unTel;
            puntos = 0;
            categoria = CategoriaHandler.GetCategoria(idCategoria);
           // dispositivos = unosDisp;
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

        public int EnergiaConsumidaPorDispositivos()
        {
            int energia = 0;

            foreach(var dispositivo in dispositivos)
            {
                energia += dispositivo.kwPorHora;
            }

            return energia;
        }
        /*
        public void AgregarDispositivoInteligente()
        {
            dispositivos.Add(new DispositivoInteligente(string unNombreDispositivo, int unKwPorHora));

        }
        */
        // public void AdaptarDispositivoEstandar

        /* public void Recategorizar()
         {
             categoria = CategoriaHandler.recategorizar(consumo); // int consumo. Recategorizar devuelve la instancia de una nueva categoria
         }
         */
    }
}