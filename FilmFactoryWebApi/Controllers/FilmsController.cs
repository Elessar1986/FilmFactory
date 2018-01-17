using Repository.UnitOnWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FilmFactoryWebApi.Controllers
{
    public class FilmsController : ApiController
    {
        UnitOfWork data = new UnitOfWork("ModelFilmTest");

        // GET: api/Films
        public IEnumerable<string> Get()
        {
            var films = data.Films.GetAll().ToList();
            return films.Select(x => x.Title);
        }

        // GET: api/Films/5
        public string Get(int id)
        {
            var film = data.Films.GetById(id);
            return film.Title;
        }

        // POST: api/Films
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Films/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Films/5
        public void Delete(int id)
        {
        }
    }
}
