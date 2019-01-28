using Insurance_Policy.Domain.Interfaces.Base;
using Insurance_Policy.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace Insurance_Policy.Infrastructure.Repositories.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, new()
    {
        public InsuranceContext Context { get; set; }

        public EntityBaseRepository(InsuranceContext context)
        {
            this.Context = context;
        }

        public bool Add(T entity)
        {
            try
            {
                var entitySet = Context.Set<T>();
                entitySet.Add(entity);
                Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            var entitySet = Context.Set<T>();
            entitySet.Attach(entity);
            entitySet.Remove(entity);
            Commit();
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            var entitySet = Context.Set<T>();
            return entitySet.AsQueryable();
        }

        public IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public bool Update(T entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
