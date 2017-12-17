using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsDB.Model;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using FilmGenericRepository.Abstract;

namespace FilmGenericRepository.Concrete
{
     public abstract class FilmGenericRepository<T> : IFilmGenericRepository<T> where T : class, new()
    {
        FilmDB context;
        IDbSet<T> dbSet;

        public FilmGenericRepository(FilmDB context)
        {
            this.context = context;
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

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
