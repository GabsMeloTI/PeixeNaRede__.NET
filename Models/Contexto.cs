using Microsoft.EntityFrameworkCore;

namespace PeixeNaRede.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Encontro> Encontro { get; set; }
        public DbSet<Captura> Captura { get; set; }
        public DbSet<Especie> Especie { get; set; }
        public DbSet<Oferta> Oferta { get; set; }
        public DbSet<Pescaria> Pescaria { get; set; }

        public DbSet<EncontroUsuario> EncontrosUsuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EncontroUsuario>()
                .HasKey(e => new { e.CdUsuario, e.CdEncontro });

            base.OnModelCreating(modelBuilder);
        }
    }

}
