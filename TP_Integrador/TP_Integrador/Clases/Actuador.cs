using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador.Clases
{
    public class Actuador : ObserverActuador
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActuadorID { get; set; }
        private List<Regla> Reglas;
        private List<DispositivoInteligente> Dispositivos;

        public void AgregarRegla(Regla unaRegla)
        {
            Reglas.Add(unaRegla);
        }

        public void EliminarRegla(Regla unaRegla)
        {
            Reglas.Remove(unaRegla);
        }

        public void AgregarDispositivo(DispositivoInteligente unDispositivo)
        {
            Dispositivos.Add(unDispositivo);
        }

        public void EliminarDispositivo(DispositivoInteligente unDispositivo)
        {
            Dispositivos.Remove(unDispositivo);
        }

        public void Update()
        {
            if (Reglas.TrueForAll(SeCumpleRegla))
            {
                foreach (DispositivoInteligente dispositivo in Dispositivos)
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