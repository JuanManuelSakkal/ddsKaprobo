using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Integrador.Clases;

namespace TP_Integrador.Helpers
{
    public class Reporte
    {
        private Usuario usuario;
        private List<Dispositivo> dispositivos;
        public Reporte(Usuario usu)
        {
            usuario = usu;
            dispositivos = DispositivoHandler.GetDispositivosByUsuarioID(usuario.UsuarioID);
        }

        public double ConsumoTotal(int periodo)
        {
            return ConsumoDispositivosEstandar(periodo) + ConsumoDispositivosInteligentes(periodo);
        }

        public double ConsumoDispositivosEstandar(int periodo)
        {
            double consumo = 0;
            foreach (var disp in dispositivos)
            {
                if (disp.GetType() == typeof(DispositivoEstandar))
                {
                    DispositivoEstandar d = (DispositivoEstandar)disp;
                    consumo += d.CalcularConsumoMensual(periodo);
                }
            }
            return consumo;
        }

        public double ConsumoDispositivosInteligentes(int periodo)
        {
            double consumo = 0;
            foreach (var disp in dispositivos)
            {
                if (disp.GetType() == typeof(DispositivoInteligente))
                {
                    DispositivoInteligente d = (DispositivoInteligente)disp;
                    consumo += d.EnergiaConsumidaEnPeriodo(periodo);
                }
            }
            return consumo;
        }

        public double ConsumoPorTransformador(int periodo, Transformador transformador)
        {
            double consumo = 0;
            List<Dispositivo> dispos = new List<Dispositivo>();

            foreach (Cliente cliente in transformador.Clientes)
            {
                dispos = DispositivoHandler.GetDispositivosByUsuarioID(cliente.UsuarioID);
                foreach (var disp in dispositivos)
                {
                    if (disp.GetType() == typeof(DispositivoEstandar))
                    {
                        DispositivoEstandar d = (DispositivoEstandar)disp;
                        consumo += d.CalcularConsumoMensual(periodo);
                    }
                    else if (disp.GetType() == typeof(DispositivoInteligente))
                    {
                        DispositivoInteligente d = (DispositivoInteligente)disp;
                        consumo += d.EnergiaConsumidaEnPeriodo(periodo);
                    }
                }
            }
            return consumo;
        }
    }
}