namespace CidicomPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IDCliente = c.Int(nullable: false, identity: true),
                        NameCliente = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDCliente);
            
            CreateTable(
                "dbo.Sitios",
                c => new
                    {
                        IDSitios = c.Int(nullable: false, identity: true),
                        nameSitios = c.String(nullable: false),
                        IDCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDSitios)
                .ForeignKey("dbo.Clientes", t => t.IDCliente, cascadeDelete: true)
                .Index(t => t.IDCliente);
            
            CreateTable(
                "dbo.Activos",
                c => new
                    {
                        IDActivos = c.Int(nullable: false, identity: true),
                        nameActivos = c.String(nullable: false),
                        IDSitios = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDActivos)
                .ForeignKey("dbo.Sitios", t => t.IDSitios, cascadeDelete: true)
                .Index(t => t.IDSitios);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        IDServicios = c.Int(nullable: false, identity: true),
                        nameServicios = c.String(nullable: false),
                        IDActivos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDServicios)
                .ForeignKey("dbo.Activos", t => t.IDActivos, cascadeDelete: true)
                .Index(t => t.IDActivos);
            
            CreateTable(
                "dbo.Tareas",
                c => new
                    {
                        IDTareas = c.Int(nullable: false, identity: true),
                        nameTareas = c.String(nullable: false),
                        IDTecnico = c.Int(nullable: false),
                        IDServicios = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDTareas)
                .ForeignKey("dbo.Servicios", t => t.IDServicios, cascadeDelete: true)
                .ForeignKey("dbo.Tecnico", t => t.IDTecnico, cascadeDelete: true)
                .Index(t => t.IDServicios)
                .Index(t => t.IDTecnico);
            
            CreateTable(
                "dbo.Tecnico",
                c => new
                    {
                        IDTecnico = c.Int(nullable: false, identity: true),
                        NameTecnico = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDTecnico);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tareas", new[] { "IDTecnico" });
            DropIndex("dbo.Tareas", new[] { "IDServicios" });
            DropIndex("dbo.Servicios", new[] { "IDActivos" });
            DropIndex("dbo.Activos", new[] { "IDSitios" });
            DropIndex("dbo.Sitios", new[] { "IDCliente" });
            DropForeignKey("dbo.Tareas", "IDTecnico", "dbo.Tecnico");
            DropForeignKey("dbo.Tareas", "IDServicios", "dbo.Servicios");
            DropForeignKey("dbo.Servicios", "IDActivos", "dbo.Activos");
            DropForeignKey("dbo.Activos", "IDSitios", "dbo.Sitios");
            DropForeignKey("dbo.Sitios", "IDCliente", "dbo.Clientes");
            DropTable("dbo.Tecnico");
            DropTable("dbo.Tareas");
            DropTable("dbo.Servicios");
            DropTable("dbo.Activos");
            DropTable("dbo.Sitios");
            DropTable("dbo.Clientes");
        }
    }
}
