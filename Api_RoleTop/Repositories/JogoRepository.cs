using Api_RoleTop.Contexts;
using Api_RoleTop.Domains;
using Api_RoleTop.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RoleTop.Repositories
{
    public class JogoRepository : RepositoryBase<Jogo>, IJogoRepository
    {
        RoleTopContext ctx = new RoleTopContext();

        public IEnumerable<Jogo> GetTodos()
        {
            return ctx.Jogo.ToList();
                
        }
    }
}
