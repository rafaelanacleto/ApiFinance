using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFinance.Context;
using ApiFinance.Entities;
using ApiFinance.Repositories.Interfaces;

namespace ApiFinance.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext db) : base(db)
        {
        }
        
    }
}