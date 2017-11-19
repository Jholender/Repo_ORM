using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApplication5.Models;

namespace WebApplication4.Repository
{
    public class AbstractRepository<T> where T : class
    {
        public virtual void Create(T entity)
        {
            using (var context = new ApplicationContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public virtual void Update(T entity)
        {
            using (var context = new ApplicationContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public virtual List<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            using (var context = new ApplicationContext())
            {
                var query = context.Set<T>().Where(expression);
                return query.ToList();
            }

        }
        public virtual void Delete(T entity)
        {
            using (var context = new ApplicationContext())
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    context.Set<T>().Attach(entity);
                }
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }
    }
}