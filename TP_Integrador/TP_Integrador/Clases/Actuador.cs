using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class Actuador : ObserverActuador
    {
        private List<Regla> reglas;
        private List<DispositivoInteligente> dispositivos;

        public void AgregarRegla(Regla unaRegla)
        {
            reglas.Add(unaRegla);
        }

        public void EliminarRegla(Regla unaRegla)
        {
            reglas.Remove(unaRegla);
        }

        public void AgregarDispositivo(DispositivoInteligente unDispositivo)
        {
            dispositivos.Add(unDispositivo);
        }

        public void EliminarDispositivo(DispositivoInteligente unDispositivo)
        {
            dispositivos.Remove(unDispositivo);
        }

        public void Update()
        {
            if (reglas.TrueForAll(SeCumpleRegla))
            {
                foreach (DispositivoInteligente dispositivo in dispositivos)
                {
                    //Hace la acción correspondiente a este actuador
                }
            }
        }

        private bool SeCumpleRegla(Regla unaRegla)
        {
            return unaRegla.SeCumple();            
        }
    }
}