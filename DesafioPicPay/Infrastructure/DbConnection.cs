using DesafioPicPay.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPicPay.Infrastructure
{
    public class DbConnection : DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options) { }

        public DbSet<Carteira> Carteira { get; set; }

        public DbSet<Transferencia> Transferencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Carteira>()
                .HasIndex(c => c.CpfCnpj)
                .IsUnique();

            modelBuilder.Entity<Carteira>()
                .Property(c => c.Saldo)
                .HasColumnType("decimal(18,2)"); // Define o tipo de coluna para Saldo como decimal com 18 dígitos no total e 2 casas decimais

            modelBuilder.Entity<Carteira>()
                .Property(c => c.Tipo)
                .HasConversion<string>();

            modelBuilder.Entity<Transferencia>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Transferencia>()
                .HasOne(t => t.Pagador) // Define o relacionamento entre Transferencia e Carteira (Pagador)
                .WithMany() // A relação é de um para muitos, mas não há necessidade de uma coleção de Transferencias na Carteira
                .HasForeignKey(t => t.IdPagador) 
                .OnDelete(DeleteBehavior.Restrict) // Restringe a exclusão do pagador se houver transferências associadas
                .HasConstraintName("FK_Tranferencia_Pagador");

            modelBuilder.Entity<Transferencia>()
                .HasOne(t => t.Recebedor)
                .WithMany()
                .HasForeignKey(t => t.IdRecebedor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Tranferencia_Recebedor");

            modelBuilder.Entity<Transferencia>()
                .Property(t => t.Valor)
                .HasColumnType("decimal(18, 2)");
        }

    }
}
