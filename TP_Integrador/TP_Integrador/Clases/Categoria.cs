using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class Categoria
    {
        public float cargoFijo { get; set; }
        public float cargoVariable { get; set; }

        public Categoria(float unCargoFijo, float unCargoVariable)
        {
            this.cargoFijo = unCargoFijo;
            this.cargoVariable = unCargoVariable;
        }

        /**** OPCION 1 ****/

        /*
         * hacer clase CategoriaHandler que sea instanciada por usuario, 
        le pase el consumo mensual, y esta instancie a su vez la Categoria con los atributos correspindientes
        */

        /**** OPCION 2 ****/
        /*
         * pasarle al constructor de Categoria el consumo mensual, desde Usuario, y cargar los atributos desde el mismo constructor
         */
    }
}