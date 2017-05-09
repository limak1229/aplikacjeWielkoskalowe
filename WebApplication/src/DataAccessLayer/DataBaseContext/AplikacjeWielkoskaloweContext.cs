using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLayer.DataBaseContext
{
    public partial class AplikacjeWielkoskaloweContext : DbContext
    {
        public virtual DbSet<CalculatedRoutes> CalculatedRoutes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=79.137.74.214;User Id=App_Wielkoskalowe;Password=gsJie3aB;Database=AplikacjeWielkoskalowe");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalculatedRoutes>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DataVersion)
                    .IsRequired()
                    .HasColumnType("nchar(10)");
            });
        }
    }
}