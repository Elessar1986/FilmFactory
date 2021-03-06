﻿using Repository.Abstract;
using FilmsDB.TestModel;
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
        ModelFilmTest context;
        IDbSet<T> dbSet;

        public GeneralRepositiry(ModelFilmTest context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public void Create(T obj)
        {
            dbSet.Add(obj);
        }

        public void Delete(T obj)
        {
            dbSet.Remove(obj);
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

        public virtual void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
