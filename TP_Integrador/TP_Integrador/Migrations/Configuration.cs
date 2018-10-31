namespace TP_Integrador.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TP_Integrador.Clases;
    using TP_Integrador.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<TP_Integrador.Data.ContextoDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TP_Integrador.Data.ContextoDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Cliente ClienteDePrueba = new Cliente(1, "NomUs", "LaPass", "Prueba", "Prueba", "Prueba", "DNI", "40000000", "4000000");

            using (var db = new ContextoDB())
            {
                DispositivoInteligente aire3500 = new DispositivoInteligente("Aire Acondicionado 3500", 1.613, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoInteligente aire2200 = new DispositivoInteligente("Aire Acondicionado 2200", 1.013, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoEstandar tvTubo21 = new DispositivoEstandar("TV Tubo Fluorescente 21'", 0.075, ClienteDePrueba);
                DispositivoEstandar tvTubo29a34 = new DispositivoEstandar("TV Tubo Fluorescente 29' a 34'", 0.175, ClienteDePrueba);
                DispositivoEstandar tvLCD = new DispositivoEstandar("TV LCD 40'", 0.18, ClienteDePrueba);
                DispositivoInteligente tvLED24 = new DispositivoInteligente("TV LED 24'", 0.04, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoInteligente tvLED32 = new DispositivoInteligente("TV LED 32'", 0.055, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoInteligente tvLED40 = new DispositivoInteligente("TV LED 40'", 0.08, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoInteligente heladeraConFreezer = new DispositivoInteligente("Heladera Con Freezer", 0.09, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoInteligente heladeraSinFreezer = new DispositivoInteligente("Heladera Sin Freezer", 0.075, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoEstandar lavarropasAutoCCalentamiento = new DispositivoEstandar("Lavarropas automático de 5kg con calentamiento de agua", 0.875, ClienteDePrueba);
                DispositivoInteligente lavarropasAutomatico = new DispositivoInteligente("Lavarropas automático de 5kg", 0.175, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoEstandar lavaropasSemiAuto = new DispositivoEstandar("Lavarropas semiautomático de 5kg", 0.1275, ClienteDePrueba);
                DispositivoEstandar ventiladorPie = new DispositivoEstandar("Ventilador de pie", 0.09, ClienteDePrueba);
                DispositivoInteligente ventiladorTecho = new DispositivoInteligente("Ventilador de techo", 0.06, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoInteligente lamparaHalo40W = new DispositivoInteligente("Lampara Halogena de 40W", 0.04, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoInteligente lamparaHalo60W = new DispositivoInteligente("Lampara Halogena de 60W", 0.06, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoInteligente lamparaHalo100W = new DispositivoInteligente("Lampara Halogena de 100W", 0.015, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoInteligente lampara11W = new DispositivoInteligente("Lampara de 11W", 0.011, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoInteligente lampara15W = new DispositivoInteligente("Lampara de 15W", 0.015, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoInteligente lampara20W = new DispositivoInteligente("Lampara de 20W", 0.02, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoInteligente pcEscritorio = new DispositivoInteligente("PC de escritorio", 0.4, ClienteDePrueba, new FabricanteDePrueba());
                DispositivoEstandar microondas = new DispositivoEstandar("Microondas convencional", 0.64, ClienteDePrueba);

                db.Dispositivos.Add(aire2200);
                db.Dispositivos.Add(aire3500);
                db.Dispositivos.Add(tvTubo21);
                db.Dispositivos.Add(tvTubo29a34);
                db.Dispositivos.Add(tvLCD);
                db.Dispositivos.Add(tvLED24);
                db.Dispositivos.Add(tvLED32);
                db.Dispositivos.Add(tvLED40);
                db.Dispositivos.Add(heladeraConFreezer);
                db.Dispositivos.Add(heladeraSinFreezer);
                db.Dispositivos.Add(lavarropasAutoCCalentamiento);
                db.Dispositivos.Add(lavarropasAutomatico);
                db.Dispositivos.Add(lavaropasSemiAuto);
                db.Dispositivos.Add(ventiladorPie);
                db.Dispositivos.Add(ventiladorTecho);
                db.Dispositivos.Add(lamparaHalo40W);
                db.Dispositivos.Add(lamparaHalo60W);
                db.Dispositivos.Add(lamparaHalo100W);
                db.Dispositivos.Add(lampara11W);
                db.Dispositivos.Add(lampara15W);
                db.Dispositivos.Add(lampara20W);
                db.Dispositivos.Add(pcEscritorio);
                db.Dispositivos.Add(microondas);

                db.SaveChanges();
            }
        }
    }
}
