using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Abstract;
using Repository.Model;
using AutoMapper;
using FilmsDB.Model;

namespace Repository.Concrette
{
    public class GenreService : IRepository<BizGenre>
    {
        FilmDB data;

        public GenreService()
        {
            data = new FilmDB();
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<genre, BizGenre>().ForMember(c => c.Genre, g => g.MapFrom(m => m.Genre1));
                cfg.CreateMap<BizGenre, genre>().ForMember(c => c.Genre1, g => g.MapFrom(m => m.Genre));
            });
        }

        public void AddOrUpdate(BizGenre item)
        {
            throw new NotImplementedException();
        }

        public void Delete(BizGenre item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BizGenre> GetAll()
        {
            return Mapper.Map<IQueryable<genre>,List<BizGenre>> (data.genre);
        }

        public BizGenre GetById(int id)
        {
            return Mapper.Map<genre, BizGenre>(data.genre.Find(id));
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
