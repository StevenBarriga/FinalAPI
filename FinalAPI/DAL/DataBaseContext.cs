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
            modelBuilder.Entity<Student>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<Subject>().HasIndex("Name", "StudentId").IsUnique();
        }

        #region DbSets

        public DbSet <Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }



        #endregion
    }
}
