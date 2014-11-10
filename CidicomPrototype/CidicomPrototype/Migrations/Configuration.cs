namespace CidicomPrototype.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CidicomPrototype.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CidicomPrototype.DAL.CidicomContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CidicomPrototype.DAL.CidicomContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var clientes = new List<Clientes>
            {
                new Clientes {NameCliente="Esteban Casallas"},
                new Clientes {NameCliente="Cidicom"},
                new Clientes {NameCliente="Javier Deheza"},
                new Clientes {NameCliente="Matias Serrano"}
            };
            clientes.ForEach(s => context.Clientes.AddOrUpdate(p => p.NameCliente, s));
            context.SaveChanges();

            var tecnicos = new List<Tecnico>
            {
                new Tecnico {NameTecnico = "cristian Calvet"},
                new Tecnico {NameTecnico = "Omar Muñiz"}
            };
            tecnicos.ForEach(s => context.Tecnicos.AddOrUpdate(p => p.NameTecnico, s));
            context.SaveChanges();

            var sitios = new List<Sitios> 
            { 
                new Sitios{IDCliente = clientes.Single(s => s.NameCliente=="Esteban Casallas").IDCliente,
                            nameSitios="casa villa ballester"},
                new Sitios{IDCliente = clientes.Single(s => s.NameCliente=="Esteban Casallas").IDCliente,
                            nameSitios="Oficina"},
                new Sitios{IDCliente = clientes.Single(s => s.NameCliente=="Cidicom").IDCliente,
                            nameSitios="Buenos Aires Capital"},
                new Sitios{IDCliente = clientes.Single(s => s.NameCliente=="Cidicom").IDCliente,
                            nameSitios="Cordoba Capital"}
            };
            foreach (Sitios e in sitios)
            {
                var sitiosInDataBase = context.Sitios.Where(
                        s => s.Clientes.IDCliente == e.IDCliente).SingleOrDefault();
                if (sitiosInDataBase == null)
                {
                    context.Sitios.Add(e);
                }
            }
            context.SaveChanges();

            var activos = new List<Activos> 
            { 
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="casa villa ballester").IDSitios,
                            nameActivos = "Aire Acondicionado r800"},
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="casa villa ballester").IDSitios,
                            nameActivos = "Baterias ref23540"},
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="casa villa ballester").IDSitios,
                            nameActivos = "servidor l500"},
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="Oficina").IDSitios,
                            nameActivos = "Aire Acondicionado r801"},
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="Oficina").IDSitios,
                            nameActivos = "Baterias ref23545"},
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="Oficina").IDSitios,
                            nameActivos = "Servidor S900"},
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="Oficina").IDSitios,
                            nameActivos = "Computador Acer"},
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="Oficina").IDSitios,
                            nameActivos = "Impresora HP L2682"},
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="Buenos Aires Capital").IDSitios,
                            nameActivos = "Aire Acondicionado r805"},
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="Buenos Aires Capital").IDSitios,
                            nameActivos = "Baterias ref23546"},
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="Buenos Aires Capital").IDSitios,
                            nameActivos = "Servidor S950"},
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="Buenos Aires Capital").IDSitios,
                            nameActivos = "Computador Bahio"},
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="Buenos Aires Capital").IDSitios,
                            nameActivos = "Impresora HP L2558"},
                new Activos{IDSitios = sitios.Single(s => s.nameSitios =="Buenos Aires Capital").IDSitios,
                            nameActivos = "Firewall"}

            };
            foreach (Activos e in activos)
            {
                var activosInDataBase = context.Activos.Where(
                        s => s.Sitios.IDSitios == e.IDSitios).SingleOrDefault();
                if (activosInDataBase == null)
                {
                    context.Activos.Add(e);
                }
            }
            context.SaveChanges();


            var servicios = new List<Servicios> 
            { 
                new Servicios{IDActivos = activos.Single(s => s.nameActivos == "Aire Acondicionado r800").IDActivos,
                                nameServicios = "Mantenimiento de Aire r800"},
                new Servicios{IDActivos = activos.Single(s => s.nameActivos == "Aire Acondicionado r801").IDActivos,
                                nameServicios = "Mantenimiento de Aire r801"},
                new Servicios{IDActivos = activos.Single(s => s.nameActivos =="Computador Bahio").IDActivos,
                            nameServicios = "Mantenimiento Computadora Bahio"},
                new Servicios{IDActivos = activos.Single(s => s.nameActivos =="Computador Acer").IDActivos,
                            nameServicios = "Mantenimiento Computadora Acer"},
                new Servicios{IDActivos = activos.Single(s => s.nameActivos == "Impresora HP L2558").IDActivos,
                            nameServicios = "mantenimiento Impresora HP L2558"},
                new Servicios{IDActivos = activos.Single(s => s.nameActivos == "Impresora HP L2558").IDActivos,
                            nameServicios = "Recarga de cartuchos de Impresora HP L2558"},
                new Servicios{IDActivos = activos.Single(s => s.nameActivos == "Impresora HP L2682").IDActivos,
                            nameServicios = "mantenimiento Impresora HP L2682"},
                new Servicios{IDActivos = activos.Single(s => s.nameActivos == "Impresora HP L2682").IDActivos,
                            nameServicios = "Recarga de cartuchos de Impresora HP L2682"}
            };
            foreach (Servicios e in servicios)
            {
                var serviciosInDataBase = context.Servicios.Where(
                        s => s.Activos.IDActivos == e.IDActivos).SingleOrDefault();
                if (serviciosInDataBase == null)
                {
                    context.Servicios.Add(e);
                }
            }
            context.SaveChanges();


            var tareas= new List<Tareas> 
            { 
                new Tareas{IDServicios = servicios.Single(s => s.nameServicios == "Mantenimiento de Aire r800").IDServicios, nameTareas = "Revision preventiva r800", IDTecnico = tecnicos.Single(s => s.NameTecnico =="cristian Calvet").IDTecnico, Estado = Estado.Proceso},
                new Tareas{IDServicios = servicios.Single(s => s.nameServicios == "Mantenimiento de Aire r801").IDServicios, nameTareas = "Revision preventiva r801", IDTecnico = tecnicos.Single(s => s.NameTecnico =="cristian Calvet").IDTecnico, Estado = Estado.Cancelado},
                new Tareas{IDServicios = servicios.Single(s => s.nameServicios == "Recarga de cartuchos de Impresora HP L2682").IDServicios, nameTareas = "compra de cartuchos de Impresora HP L2682", IDTecnico = tecnicos.Single(s => s.NameTecnico =="Omar Muñiz").IDTecnico, Estado = Estado.Finalizado},
            };
            foreach (Tareas e in tareas)
            {
                var tareasInDataBase = context.Tareas.Where(
                        s => s.Servicios.IDServicios == e.IDServicios).SingleOrDefault();
                if (tareasInDataBase == null)
                {
                    context.Tareas.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
