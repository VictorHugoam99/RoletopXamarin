using Api_RoleTop.Contexts;
using Api_RoleTop.Domains;
using Api_RoleTop.Interfaces;
using Api_RoleTop.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RoleTop.Repositories
{
    public class EstadioRepository : RepositoryBase<Estadio>, IEstadioRepository
    {
        RoleTopContext ctx = new RoleTopContext();

        IEnumerable<Estadio> estadios;

        public IEnumerable<Estadio> PegarEventoEstadio(int id)
        {
            estadios = ctx.Estadio.Where(e => e.Evento == id);

            return estadios;
        }
    }
}
