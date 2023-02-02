
using FilmesApi.Models;
using FilmesAPI.Models;
using filmesAPIalura.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1:1
            modelBuilder.Entity<Endereco>()
               .HasOne(endereco => endereco.Cinema)
               .WithOne(cinema => cinema.Endereco)
               .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);
 

            modelBuilder.Entity<Cinema>()
               .HasOne(endereco => endereco.Gerente)
               .WithMany(gerente => gerente.Cinemas)
               .HasForeignKey(cinema => cinema.GerenteId);

            //filme da sessao
            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId);

            //cinema da sessao
            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId);
            //ingresso da sessao
            modelBuilder.Entity<Ingresso>()
                        .HasOne(ingresso => ingresso.Sessao)
                        .WithMany(sessao => sessao.Ingressos)
                        .HasForeignKey(ingresso => ingresso.SessaoId);
        }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; } 
        public DbSet<Sessao> Sessoes { get; set; } 
        public DbSet<Ingresso> Ingressos { get; set; }
    }
}