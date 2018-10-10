using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public static class DispositivoInteligenteHandler
    {
        private static List<DispositivoInteligente> dispositivos = new List<DispositivoInteligente>();

        public static List<DispositivoInteligente> GetDispositivoInteligentes()
        {
            //SOLO PARA PRUEBAS, LUEGO SE CARGARÁ DE LA BD (quedá definir cuando)
            DispositivoInteligente aire3500 = new DispositivoInteligente("Aire 3500", 1.613, new FabricanteDePrueba());
            DispositivoInteligente aire2200 = new DispositivoInteligente("Aire 2200", 1.013, new FabricanteDePrueba());
            DispositivoInteligente tvLed40 = new DispositivoInteligente("TV Led 40", 0.08, new FabricanteDePrueba());

            dispositivos.Add(aire3500);
            dispositivos.Add(aire2200);
            dispositivos.Add(tvLed40);

            return dispositivos;
        }
    }
}