using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Films.DOL.Model;

namespace WcfDataService
{

    public class Service1 : IData
    {

        FilmDB db = new FilmDB();

        public void AddFilm(film film)
        {
            db.films.Add(film);
            db.SaveChanges();
        }

        public string ConnectionTest()
        {
            return $"connection set";
        }

        public IEnumerable<film> GetFilms()
        {
            return db.films.ToList();
        }


        public void Test()
        {
            
        }

    }
}
