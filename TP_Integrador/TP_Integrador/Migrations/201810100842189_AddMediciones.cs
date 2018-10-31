namespace TP_Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMediciones : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                "dbo.Migraciones",
                m => new
                {
                    MigracionID = m.Int(false, true),
                    Valor = m.Double()
                }).PrimaryKey(p => p.MigracionID);*/
        }
        
        public override void Down()
        {
        }
    }
}
