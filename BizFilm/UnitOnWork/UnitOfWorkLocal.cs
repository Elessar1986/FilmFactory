using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsDB.TestModel;
using Repository.ConcretteLocal;
using Repository.Abstract;

namespace Repository.UnitOnWork
{
    public class UnitOfWorkLocal : IUnitOfWork
    {
        private FilmDB context;

        FilmRepository filmRepository;
        DirectorRepository directorRepository;
        GenreRepository genreRepository;

        public UnitOfWorkLocal(string conectionString)
        {
            context = new FilmDB(conectionString);
        }

        public IRepository<films> Films
        {
            get
            {
                if (filmRepository == null)
                    filmRepository = new FilmRepository(context);
                return filmRepository;
            }
        }

        public IRepository<genre> Genres
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(context);
                return genreRepository;
            }
        }

        public IRepository<director> Director
        {
            get
            {
                if (directorRepository == null)
                    directorRepository = new DirectorRepository(context);
                return directorRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
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
