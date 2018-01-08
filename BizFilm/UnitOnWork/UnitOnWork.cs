using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsDB.TestModel;
using Repository.Concrette;
using System.Data.Entity;

namespace Repository.UnitOnWork
{
    public class UnitOnWork : IDisposable
    {
        private ModelFilmTest context = new ModelFilmTest();

        FilmRepository filmRepository;
        DirectorRepository directorRepository;
        GenreRepository genreRepository;

        public FilmRepository Films
        {
            get
            {
                if (filmRepository == null)
                    filmRepository = new FilmRepository(context);
                return filmRepository;
            }
        }

        public GenreRepository Genres
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(context);
                return genreRepository;
            }
        }

        public DirectorRepository Director
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
