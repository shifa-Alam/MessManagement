
using MM.Core.Entities;
using MM.Core.Infra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MM.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly MMDBContext context;
        public GenericRepository(MMDBContext context)
        {
            this.context = context;
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }
        public T Update(T entity)
        {
           return context.Set<T>().Update(entity).Entity;
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }
        public virtual IEnumerable<T> GetAll()
        {
            //return context.Set<T>().ToList();
            return context.Set<T>().Where(e => e.Active==true).ToList();

            //return context.Set<T>().Where(e => (bool)e.GetType().GetProperty("Active").GetValue(e) == true).ToList();


        }
        public T GetById(long id)
        {
            return context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }

      
    }
}
