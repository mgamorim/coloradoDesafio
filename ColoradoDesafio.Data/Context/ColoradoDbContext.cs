using ColoradoDesafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ColoradoDesafio.Data.Context
{
    public class ColoradoDbContext : DbContext
    {
        public ColoradoDbContext(DbContextOptions<ColoradoDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TipoTelefone> TiposTelefone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodigoCliente);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(200);
                entity.Property(e => e.TipoPessoa).IsRequired().HasMaxLength(20);
                entity.Property(e => e.CPF).HasMaxLength(14);
                entity.Property(e => e.Documento).HasMaxLength(200);
                entity.Property(e => e.Cidade).HasMaxLength(100);
                entity.Property(e => e.Endereco).HasMaxLength(200);
                entity.Property(e => e.Estado).HasMaxLength(2);

                entity.HasMany(e => e.Telefones)
                      .WithOne(t => t.Cliente)
                      .HasForeignKey(t => t.CodigoCliente)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasKey(e => e.NumeroTelefone);
                entity.Property(e => e.TipoTelefone).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Numero).IsRequired().HasMaxLength(20);
                entity.Property(e => e.DDD).HasMaxLength(10);
                entity.Property(e => e.Observacao).HasMaxLength(200);
                entity.Property(e => e.Descricao).HasMaxLength(200);
            });

            modelBuilder.Entity<TipoTelefone>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Descricao).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Ativo).HasDefaultValue(true);

                entity.HasData(
                    new TipoTelefone { Id = 1, Descricao = "RESIDENCIAL", Ativo = true },
                    new TipoTelefone { Id = 2, Descricao = "COMERCIAL", Ativo = true },
                    new TipoTelefone { Id = 3, Descricao = "WHATSAPP", Ativo = true },
                    new TipoTelefone { Id = 4, Descricao = "CELULAR", Ativo = true }
                );
            });
        }
    }
}
