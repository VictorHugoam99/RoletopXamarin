using Microsoft.EntityFrameworkCore;
using Api_RoleTop.Contexts;
using Api_RoleTop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_RoleTop.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        RoleTopContext ctx = new RoleTopContext();
        public void Add(TEntity obj)
        {
            try
            {
                ctx.Set<TEntity>().Add(obj);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(TEntity obj)
        {
            try
            {
                ctx.Set<TEntity>().Remove(obj);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
             return ctx.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return ctx.Set<TEntity>().Find(id);
        }

        public void Update(TEntity obj)
        {
            try
            {
                ctx.Entry(obj).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
