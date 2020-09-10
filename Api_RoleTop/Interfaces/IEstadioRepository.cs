using Api_RoleTop.Domains;
using Api_RoleTop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RoleTop.Interfaces
{
    public interface IEstadioRepository : IRepositoryBase<Estadio>
    {
        IEnumerable<Estadio> PegarEventoEstadio(int id);
    }
}
