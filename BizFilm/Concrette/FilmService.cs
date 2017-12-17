using Repository.Abstract;
using Repository.Model;
using FilmsDB.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Repository.Concrette
{
    public class FilmService : IRepository<BizFilm>
    {
        FilmDB data;
        //IDbSet<films> dbSet;

        public FilmService()
        {
            data = new FilmDB();
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<films, BizFilm>().ForMember(f => f.Genre, sd => sd.MapFrom(d => d.genre));
                cfg.CreateMap<BizFilm, films>().ForMember(f => f.genre, sd => sd.MapFrom(d => d.Genre));

                cfg.CreateMap<genre, BizGenre>().ForMember(c => c.Genre, g => g.MapFrom(m => m.Genre1));
                cfg.CreateMap<BizGenre, genre>().ForMember(c => c.Genre1, g => g.MapFrom(m => m.Genre));

            });
        }

        public void AddOrUpdate(BizFilm filmItem)
        {
            films Film;
            Film = Mapper.Map<BizFilm, films>(filmItem);

            //var genresList = new List<genre>();
            //foreach (var g in Film.genre)
            //{
            //    genresList.Add(data.genre.Find(g.Id));
            //}
            //Film.genre = genresList;

            data.films.AddOrUpdate(Film);
            Save();
        }


        public void Delete(BizFilm item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BizFilm> GetAll()
        {
            return Mapper.Map<IQueryable<films>, List<BizFilm>>(data.films.Include(g => g.genre));
        }

        public BizFilm GetById(int id)
        {
            return Mapper.Map<films, BizFilm>(data.films.Find(id));
        }

        public void Save()
        {
            data.SaveChanges();
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
