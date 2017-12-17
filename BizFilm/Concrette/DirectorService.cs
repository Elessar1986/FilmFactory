using Repository.Abstract;
using Repository.Model;
using FilmsDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrette
{
    public class DirectorService : IRepository<BizDirector>
    {
        FilmDB data;

        public DirectorService()
        {
            data = new FilmDB();
        }

        public void AddOrUpdate(BizDirector item)
        {
            throw new NotImplementedException();
        }

        public void Delete(BizDirector item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BizDirector> GetAll()
        {
            throw new NotImplementedException();
        }

        public BizDirector GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    data.Dispose();
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
