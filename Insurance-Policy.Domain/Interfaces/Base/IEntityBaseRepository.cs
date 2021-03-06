﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Domain.Interfaces.Base
{
    public interface IEntityBaseRepository<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate);
        T Get(long id);
        void Commit();
    }
}
