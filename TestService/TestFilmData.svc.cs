using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity;
using TestService.DataContract;
using Repository.Concrette;
using Repository.Model;
using AutoMapper;
using Repository.Abstract;
using FilmsDB.Model;

namespace TestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestFilmData" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestFilmData.svc or TestFilmData.svc.cs at the Solution Explorer and start debugging.
    public class TestFilmData : ITestFilmData
    {
        //IBizService<FilmService> filmData;
        //FilmService filmsData;
        //GenreService genreData;
        IRepository<films> filmsData;
        IRepository<genre> genreData;
        IRepository<director> directorData;

        public TestFilmData()
        {
            filmsData = new FilmRepository();
            genreData = new GenreRepository();
            directorData = new DirectorRepository();
        }

        public void AddOrUpdateFilm(FilmContract film)
        {
            var Film = (films)film;
            var Genres = new List<genre>();
            film.Genre.ForEach(x =>
            {
                Genres.Add(genreData.GetById(x.Id));
            });
            Film.genre = Genres;
            filmsData.AddOrUpdate(Film);
        }



        public string CheckConnection()
        {
            return "Connection OK!";
        }

        public void DeleteFilm(int id)
        {

        }

        public FilmContract GetFilmById(int id)
        {
            return filmsData.GetById(id);
        }

        public List<GenreContract> GetGenres()
        {
            return genreData.GetAll().Select(x => (GenreContract)x).ToList();
            //return new List<GenreContract>();
        }

        public List<FilmContract> GetFilms()
        {

            return filmsData.GetAll().Select(x => (FilmContract)x).ToList();

        }

    }
}
