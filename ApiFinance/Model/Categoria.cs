using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFinance.Model
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoTransacao TipoPadrao { get; set; } // Pode ser útil para sugestão ao cadastrar
                                                      // Propriedade para a chave estrangeira do usuário
        public string UserId { get; set; }

        // Propriedade de navegação para o usuário associado
        [ForeignKey("UserId")] // Opcional, mas boa prática para clareza
        public ApplicationUser User { get; set; }

        public Categoria() { } // Construtor sem parâmetros para Entity Framework Core

        public Categoria(int id, string nome, TipoTransacao tipoPadrao, string userId)
        {
            Id = id;
            Nome = nome;
            TipoPadrao = tipoPadrao;
            UserId = userId;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}