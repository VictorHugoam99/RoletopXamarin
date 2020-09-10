using Api_RoleTop.Contexts;
using Api_RoleTop.Domains;
using Api_RoleTop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RoleTop.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        RoleTopContext ctx = new RoleTopContext();
        public Usuario Login(string email_apelido, string senha)
        {
            return ctx.Usuario.FirstOrDefault(u => (u.Email == email_apelido) || (u.Apelido == email_apelido) && (u.Senha == senha));
        }
    }
}
