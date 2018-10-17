using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Integrador.Data;

namespace TP_Integrador.Clases
{
    public static class DispositivoHandler
    {
        public static List<Dispositivo> GetDispositivos()
        {
            List<Dispositivo> dispositivos = new List<Dispositivo>();

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
            List<Dispositivo> dispositivos = new List<Dispositivo>();

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

        public static List<DispositivoEstandar> GetDispositivosEstandar(int usuarioID)
        {
            List<DispositivoEstandar> dispositivos = new List<DispositivoEstandar>();
            using (var db = new ContextoDB())
            {
                var query = from d in db.Dispositivos
                            select d;
                foreach (var dispositivo in query)
                {
                    if (dispositivo.Cliente_UsuarioID == usuarioID && dispositivo.GetType() == typeof(DispositivoEstandar))
                    {
                        DispositivoEstandar de = (DispositivoEstandar)dispositivo;
                        dispositivos.Add(de);
                    }
                }
            }
            return dispositivos;
        }

        public static List<DispositivoInteligente> GetDispositivosInteligentes(int usuarioID)
        {
            List<DispositivoInteligente> dispositivos = new List<DispositivoInteligente>();

            using (var db = new ContextoDB())
            {
                var query = from d in db.Dispositivos
                            select d;
                foreach (var dispositivo in query)
                {
                    if (dispositivo.Cliente_UsuarioID == usuarioID && dispositivo.GetType() == typeof(DispositivoInteligente))
                    {
                        DispositivoInteligente di = (DispositivoInteligente)dispositivo;
                        dispositivos.Add(di);
                    }
                }
            }
            return dispositivos;
        }
    }
}