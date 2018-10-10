using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador.Clases
{
    public class Regla : SubjectObserverRegla
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReglaID { get; set; }
        private bool SeEstaCumpliendo;

        public bool SeCumple()
        {
            return SeEstaCumpliendo;
        }

        public void SeCumple(bool valor)
        {
            SeEstaCumpliendo = valor;
        }
    }
}