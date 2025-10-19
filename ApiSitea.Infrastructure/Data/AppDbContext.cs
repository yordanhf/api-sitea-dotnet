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

        public DbSet<Medicamento> Medicamentos { get; set; } = null!;
        public DbSet<AntecedentePPP> AntecedentesPPP { get; set; } = null!;
        public DbSet<Centro> Centros { get; set; } = null!;
        public DbSet<CClinica> CClinicas { get; set; } = null!;
        public DbSet<Comorbilidad> Comorbilidades { get; set; } = null!;
        public DbSet<Diagnostico> Diagnosticos { get; set; } = null!;
        public DbSet<Fortaleza> Fortalezas { get; set; } = null!;
        public DbSet<TipoInterconsulta> TiposInterconsulta { get; set; } = null!;
        public DbSet<TipoExamen> TiposExamen { get; set; } = null!;
        public DbSet<VinculoInstitucional> VinculosInstitucionales { get; set; } = null!;
        public DbSet<Municipio> Municipios { get; set; } = null!;
        public DbSet<Paciente> Pacientes { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicamento>(b => { 
                b.HasKey(x => x.Id);
                b.Property(x => x.Nombre).IsRequired().HasMaxLength(200);
            });
            modelBuilder.Entity<AntecedentePPP>(b => { 
                b.HasKey(x => x.Id); 
                b.Property(x => x.Nombre).IsRequired().HasMaxLength(200);
            });           
            modelBuilder.Entity<CClinica>(b => { 
                b.HasKey(x => x.Id); 
                b.Property(x => x.Nombre).IsRequired().HasMaxLength(200);
            });
            modelBuilder.Entity<Comorbilidad>(b => { 
                b.HasKey(x => x.Id); 
                b.Property(x => x.Nombre).IsRequired().HasMaxLength(200);
            });
            modelBuilder.Entity<Fortaleza>(b => { 
                b.HasKey(x => x.Id);
                b.Property(x => x.Nombre).IsRequired().HasMaxLength(200); 
            });
            modelBuilder.Entity<TipoInterconsulta>(b => { 
                b.HasKey(x => x.Id); 
                b.Property(x => x.Nombre).IsRequired().HasMaxLength(200); 
            });
            modelBuilder.Entity<TipoExamen>(b => {
                b.HasKey(x => x.Id);
                b.Property(x => x.Nombre).IsRequired().HasMaxLength(200); 
            });

            modelBuilder.Entity<Centro>(entity => {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(x => x.Descripcion).HasMaxLength(1000).IsRequired(false);
                entity.HasMany(c => c.Pacientes).WithOne(p => p.Centro).HasForeignKey(p => p.CentroId).OnDelete(DeleteBehavior.Restrict);
            });      

            modelBuilder.Entity<Diagnostico>(entity => { 
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Nombre).IsRequired().HasMaxLength(200);                 
            });           

            modelBuilder.Entity<VinculoInstitucional>(entity => { 
                entity.HasKey(x => x.Id); 
                entity.Property(x => x.Nombre).IsRequired().HasMaxLength(200);                

            });
            modelBuilder.Entity<Paciente>(entity => {
                // ... otras configuraciones ...

                // REEMPLAZAR:
                // entity.Property(p => p.Provincia).HasConversion<string>().IsRequired();
                // Por:
                entity.Property(p => p.ProvinciaId).IsRequired();
                

                // La configuración del Municipio se mantiene similar, solo cambia el tipo de ID
                entity.HasOne(p => p.Municipio)
                      .WithMany()
                      .HasForeignKey(p => p.MunicipioId)
                      .OnDelete(DeleteBehavior.Restrict);

                // ... resto de las configuraciones ...
            });
           
            modelBuilder.Entity<Paciente>(entity => {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Apellidos).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Ci).IsRequired().HasMaxLength(11);
                entity.Property(p => p.Sexo).IsRequired().HasMaxLength(20);
                entity.Property(p => p.Raza).HasMaxLength(50);
                entity.Property(p => p.Direccion).HasMaxLength(300);
                entity.Property(p => p.MotivoConsulta).HasMaxLength(500);
                entity.Property(p => p.Correo).HasMaxLength(200);
                entity.Property(p => p.Telefono).HasMaxLength(50);
                entity.Property(p => p.DescripcionTerapia).HasMaxLength(500);
                entity.Property(p => p.ProvinciaId).IsRequired();
                entity.Property(p => p.MunicipioId).IsRequired();
                entity.HasOne(p => p.Provincia).WithMany();
                entity.HasOne(p => p.Municipio).WithMany();
                entity.HasOne(p => p.Centro).WithMany(v => v.Pacientes).HasForeignKey(p => p.CentroId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Diagnostico).WithMany(v => v.Pacientes).HasForeignKey(p => p.DiagnosticoId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.VinculoInstitucional).WithMany(v => v.Pacientes).HasForeignKey(p => p.VinculoInstitucionalId).OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(p => p.Nombre);
                entity.HasIndex(p => p.Apellidos);
                entity.HasIndex(p => p.Ci).IsUnique();
            });
         
            base.OnModelCreating(modelBuilder);            
        }
    }
}
