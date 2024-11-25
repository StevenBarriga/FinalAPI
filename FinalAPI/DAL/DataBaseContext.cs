using FinalAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace FinalAPI.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options ) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Asignature>().HasIndex("Name", "StudentId").IsUnique();
        }
        #region DbSets

        public DbSet <Student> Students { get; set; }

        public DbSet<Asignature> Asignatures { get; set; }

        #endregion
    }
}
