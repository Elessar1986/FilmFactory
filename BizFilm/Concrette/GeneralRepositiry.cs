using Repository.Abstract;
using FilmsDB.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrette
{
    public abstract class GeneralRepositiry<T> : IRepository<T>  where T : class, new()
    {
        FilmDB context;
        IDbSet<T> dbSet;

        public GeneralRepositiry()
        {
            this.context = new FilmDB();
            dbSet = context.Set<T>();
        }

        public void AddOrUpdate(T obj)
        {
            dbSet.AddOrUpdate(obj);
            
            context.SaveChanges();
        }

        public void Delete(T obj)
        {
            dbSet.Remove(obj);
            context.SaveChanges();
        }

        //public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        //{
        //    return dbSet.Where(predicate);
        //}

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
