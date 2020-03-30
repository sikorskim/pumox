using Microsoft.EntityFrameworkCore;
using Pumox.Interfaces;
using Pumox.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pumox.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
        {
            protected PumoxContext PumoxContext { get; set; }

            public RepositoryBase(PumoxContext pumoxContext)
            {
                this.PumoxContext = pumoxContext;
            }

            public IQueryable<T> FindAll()
            {
                return this.PumoxContext.Set<T>().AsNoTracking();
            }

            public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
            {
                return this.PumoxContext.Set<T>().Where(expression).AsNoTracking();
            }

            public void Create(T entity)
            {
                this.PumoxContext.Set<T>().Add(entity);
            }

            public void Update(T entity)
            {
                this.PumoxContext.Set<T>().Update(entity);
            }

            public void Delete(T entity)
            {
                this.PumoxContext.Set<T>().Remove(entity);
            }
        }
    }
