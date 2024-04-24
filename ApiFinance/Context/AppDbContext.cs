using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFinance.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiFinance.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Despesas> Despesas { get; set; }

        public DbSet<Renda> Rendas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // aplica as configurações de mapeamento das entidades
            // do banco de dados contidas em uma determinada assembly
            // (conjunto de classes) ao objeto ModelBuilder durante a
            // criação do modelo.
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            builder.Entity<Categoria>().HasKey(t => t.Id);
            builder.Entity<Categoria>().
                Property(p => p.Nome).HasMaxLength(100).IsRequired();

            builder.Entity<Categoria>().
              Property(p => p.Cor).HasMaxLength(100).IsRequired();

            // 1 : N => Categoria : Mangas
            builder.Entity<Categoria>().HasMany(c => c.Despesas)
                .WithOne(b => b.Categoria)
                .HasForeignKey(b => b.CategoriaId);

            //define os dados iniciais para a entidade Categoria
            builder.Entity<Categoria>().HasData(
               new Categoria(1, "Ativo", "blue"),
               new Categoria(2, "Passivo", "red"),
               new Categoria(3, "Investimento", "red"),
               new Categoria(4, "Outros", "gray")
             );

            builder.Entity<Despesas>().HasKey(t => t.Id);

            //configura o tamanho máximo das propriedades que irão gerar colunas com tamanho correspondentes 
            builder.Entity<Despesas>().Property(p => p.Nome).HasMaxLength(200).IsRequired();
            builder.Entity<Despesas>().Property(p => p.Valor).IsRequired().HasPrecision(10, 2);

            // Define o comportamento de exclusão de todas as chaves estrangeiras
            // no modelo de dados como ClientSetNull, para que a exclusão de uma
            // entidade relacionada resulte na definição dos valores das chaves
            // estrangeiras como null nas entidades referenciadas.
            foreach (var relationship in builder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        }


    }
}