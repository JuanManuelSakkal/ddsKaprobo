using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Integrador.Data;

namespace TP_Integrador.Clases
{
    public static class DispositivoHandler
    {
        private static List<Dispositivo> dispositivos = new List<Dispositivo>();

        public static List<Dispositivo> GetDispositivos()
        {
            using (var db = new ContextoDB())
            {
                var query = from d in db.Dispositivos
                            select d;
                foreach (var dispositivo in query)
                {
                    dispositivos.Add(dispositivo);
                }
            }
            return dispositivos;
        }

        public static List<Dispositivo> GetDispositivosByUsuarioID(int usuarioID)
        {
            using (var db = new ContextoDB())
            {
                var query = from d in db.Dispositivos
                            select d;
                foreach (var dispositivo in query)
                {
                    if (dispositivo.Cliente_UsuarioID == usuarioID)
                    {
                        dispositivos.Add(dispositivo);
                    }
                }
            }
            return dispositivos;
        }
    }
}