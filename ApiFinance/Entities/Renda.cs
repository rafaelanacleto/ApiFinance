using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFinance.Entities
{
    public class Renda : Entity
    {
        public string? Nome { get; set; }
        public double Valor { get; set; }
        public DateTime DtCadastro { get; set; }

    }
}