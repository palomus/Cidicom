using CidicomPrototype.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CidicomPrototype.DAL
{
    public class CidicomContext : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Sitios> Sitios { get; set; }
        public DbSet<Activos> Activos { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Tareas> Tareas { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}