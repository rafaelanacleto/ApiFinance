using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiFinance.Entities;

namespace ApiFinance.DTOs
{
    public class DespesasDTO
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O Nome é requerido")]
        [MinLength(3)]
        [MaxLength(200)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O Valor é requerido")]
        public double Valor { get; set; }
        public DateTime DtCadastro { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

    }
}