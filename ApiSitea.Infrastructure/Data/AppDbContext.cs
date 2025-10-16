using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiSitea.Domain.Entities;

namespace ApiSitea.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

            
        }

        public DbSet<Medicamento> Medicamentos => Set<Medicamento>();
        public DbSet<AntecedentePPP> AntecedentesPPP => Set<AntecedentePPP>();
        public DbSet<Centro> Centros => Set<Centro>();
        public DbSet<CClinica> CClinicas => Set<CClinica>();
        public DbSet<Comorbilidad> Comorbilidades => Set<Comorbilidad>();
        public DbSet<Diagnostico> Diagnosticos => Set<Diagnostico>();
        public DbSet<Fortaleza> Fortalezas => Set<Fortaleza>();
        public DbSet<TipoInterconsulta> TiposInterconsulta => Set<TipoInterconsulta>();
        public DbSet<TipoExamen> TiposExamen => Set<TipoExamen>();
        public DbSet<VinculoInstitucional> VinculosInstitucionales => Set<VinculoInstitucional>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicamento>(b => { b.HasKey(x => x.Id);b.Property(x => x.Nombre).IsRequired().HasMaxLength(200);});
            modelBuilder.Entity<AntecedentePPP>(b => { b.HasKey(x => x.Id); b.Property(x => x.Nombre).IsRequired().HasMaxLength(200); });
            modelBuilder.Entity<Centro>(b => { b.HasKey(x => x.Id); b.Property(x => x.Nombre).IsRequired().HasMaxLength(200); b.Property(x => x.Descripcion).HasMaxLength(1000).IsRequired(false); });
            modelBuilder.Entity<CClinica>(b => { b.HasKey(x => x.Id); b.Property(x => x.Nombre).IsRequired().HasMaxLength(200); });
            modelBuilder.Entity<Comorbilidad>(b => { b.HasKey(x => x.Id); b.Property(x => x.Nombre).IsRequired().HasMaxLength(200); });
            modelBuilder.Entity<Diagnostico>(b => { b.HasKey(x => x.Id); b.Property(x => x.Nombre).IsRequired().HasMaxLength(200); });
            modelBuilder.Entity<Fortaleza>(b => { b.HasKey(x => x.Id); b.Property(x => x.Nombre).IsRequired().HasMaxLength(200); });
            modelBuilder.Entity<TipoInterconsulta>(b => { b.HasKey(x => x.Id); b.Property(x => x.Nombre).IsRequired().HasMaxLength(200); });
            modelBuilder.Entity<TipoExamen>(b => { b.HasKey(x => x.Id); b.Property(x => x.Nombre).IsRequired().HasMaxLength(200); });
            modelBuilder.Entity<VinculoInstitucional>(b => { b.HasKey(x => x.Id); b.Property(x => x.Nombre).IsRequired().HasMaxLength(200); });

            base.OnModelCreating(modelBuilder);            
        }
    }
}
