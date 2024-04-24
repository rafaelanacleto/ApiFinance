using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFinance.DTOs
{
    public class RendaDTO
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O Nome é requerido")]
        [MinLength(3)]
        [MaxLength(200)]
        public string? Nome { get; set; }
        public double Valor { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}