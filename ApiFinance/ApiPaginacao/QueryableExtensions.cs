using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFinance.Entities;

namespace ApiFinance.ApiPaginacao
{
    public static class QueryableExtensions
{
    public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, Paginacao paginacao)
    {
        return queryable
            .Skip((paginacao.Pagina - 1) * paginacao.QuantidadePorPagina)
            .Take(paginacao.QuantidadePorPagina);
    }
}
}