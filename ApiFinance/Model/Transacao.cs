using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFinance.Model
{
    public class Transacao
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public TipoTransacao Tipo { get; set; }
        // Chave estrangeira para Categoria
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        // Propriedade para a chave estrangeira do usuário
        public string UserId { get; set; }

        // Propriedade de navegação para o usuário associado
        [ForeignKey("UserId")] // Opcional, mas boa prática para clareza
        public ApplicationUser User { get; set; }

        public Transacao() { } // Construtor sem parâmetros para Entity Framework Core

        public Transacao(int id, decimal valor, DateTime data, string descricao, TipoTransacao tipo, Categoria categoria, string userId)
        {
            Id = id;
            Valor = valor;
            Data = data;
            Descricao = descricao;
            Tipo = tipo;
            Categoria = categoria;
            UserId = userId;
        }

        public override string ToString()
        {
            string sinal = (Tipo == TipoTransacao.Despesa) ? "-" : "+";
            return $"{Data.ToShortDateString()} - {Descricao} ({Categoria.Nome}): {sinal}{Valor:C}";
        }
    }
}