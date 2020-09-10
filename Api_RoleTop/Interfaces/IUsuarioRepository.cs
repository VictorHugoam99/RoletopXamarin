using Api_RoleTop.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RoleTop.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario Login(string email_apelido, string senha);
    }
}
