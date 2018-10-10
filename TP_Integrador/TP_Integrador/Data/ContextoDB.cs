using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TP_Integrador.Clases;

namespace TP_Integrador.Data
{
    public class ContextoDB : DbContext
    {
        public DbSet<Actuador> Actuadores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Regla> Reglas { get; set; }
        public DbSet<Restriccion> Restricciones { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<Transformador> Transformadores { get; set; }
        public DbSet<ZonaGeografica> ZonasGeograficas { get; set; }

        //public ContextoDB(): base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-TP_Integrador-20180508105857;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        public ContextoDB() : base(@"Data Source=(localdb)\v11.0;Initial Catalog=EFPrueba;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            
        }
    }
}