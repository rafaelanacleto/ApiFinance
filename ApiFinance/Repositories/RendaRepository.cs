using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFinance.Context;
using ApiFinance.Entities;
using ApiFinance.Repositories.Interfaces;

namespace ApiFinance.Repositories
{
    public class RendaRepository : Repository<Renda>, IRendaRepository
    {        
        public RendaRepository(AppDbContext db) : base(db)
        {
        }
    }
}