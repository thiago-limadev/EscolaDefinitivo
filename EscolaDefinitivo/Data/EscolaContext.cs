
using EscolaDefinitivo.Data.EntityConfig;
using EscolaDefinitivo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EscolaDefinitivo.Data
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options) : base (options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new CursoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

    }
}
