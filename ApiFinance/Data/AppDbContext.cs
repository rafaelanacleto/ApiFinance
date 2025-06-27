using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFinance.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiFinance.Data
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
    {
        // DbSet para a entidade Categoria
        public DbSet<Categoria> Categorias { get; set; }

        // DbSet para a entidade Transacao
        public DbSet<Transacao> Transacoes { get; set; }

        // Se você tiver outras classes de modelo, adicione-as aqui também, por exemplo:
        // public DbSet<OutraClasse> OutrasClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Chame o método base para configurar o Identity

            // Configuração para a entidade Categoria
            builder.Entity<Categoria>()
                .HasOne(c => c.User)              // Uma Categoria tem um Usuário
                .WithMany()                       // Um Usuário pode ter muitas Categorias (sem propriedade de navegação de volta em ApplicationUser)
                .HasForeignKey(c => c.UserId)     // A chave estrangeira é UserId
                .OnDelete(DeleteBehavior.Cascade); // Opcional: Se o usuário for deletado, suas categorias também são. Considere suas regras de negócio.

            // Configuração para a entidade Transacao
            builder.Entity<Transacao>()
                .HasOne(t => t.User)              // Uma Transacao tem um Usuário
                .WithMany()                       // Um Usuário pode ter muitas Transacoes (sem propriedade de navegação de volta em ApplicationUser)
                .HasForeignKey(t => t.UserId)     // A chave estrangeira é UserId
                .OnDelete(DeleteBehavior.Cascade); // Opcional: Se o usuário for deletado, suas transações também são.

            // Configuração para o relacionamento entre Transacao e Categoria
            builder.Entity<Transacao>()
                .HasOne(t => t.Categoria)           // Uma Transacao tem uma Categoria
                .WithMany()                         // Uma Categoria pode ter muitas Transacoes (sem propriedade de navegação de volta em Categoria)
                .HasForeignKey(t => t.CategoriaId)  // A chave estrangeira é CategoriaId
                .OnDelete(DeleteBehavior.Restrict); // Opcional: Não permite deletar uma categoria se houver transações associadas. Ou .SetNull, etc.
        }
    }
}