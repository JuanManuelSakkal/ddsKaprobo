using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador.Clases
{
    public abstract class Fabricante
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FabricanteID { get; set; }
    }
}