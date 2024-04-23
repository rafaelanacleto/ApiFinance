using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFinance.Entities
{
    public class Paginacao
    {
        public int Pagina { get; set; } = 1;
        public int QuantidadePorPagina { get; set; } = 3;
    }
}