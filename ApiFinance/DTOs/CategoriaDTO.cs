using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFinance.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "O Nome é requerido")]
        //[MinLength(3)]
        //[MaxLength(100)]
        public string? Nome { get; set; }

        //[Required(ErrorMessage = "O Nome da cor é requerido")]
        //[MinLength(3)]
        //[MaxLength(100)]
        public string? Cor { get; set; }
    }
}