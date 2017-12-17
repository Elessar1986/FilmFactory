using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity;
using TestService.DataContract;
using Repository.Concrette;
using Repository.UnitOnWork;
//using Repository.Model;
using AutoMapper;
using Repository.Abstract;
using FilmsDB.Model;

namespace TestService
{

    public class TestFilmData : ITestFilmData
    {

        UnitOnWork data = new UnitOnWork();

        public TestFilmData()
        {

        }

        public void AddFilm(FilmContract film)
        {
            var Film = (films)film;
            var Genres = new List<genre>();
            film.Genre.ForEach(x =>
            {
                Genres.Add(data.Genres.GetById(x.Id));
            });
            Film.genre = Genres;
            data.Films.Create(Film);
            data.Save();
        }

        public void UpdateFilm(FilmContract film)
        {
            DeleteFilm(film.Id);
            AddFilm(film);
            //var Film = (films)film;
            //var Genres = new List<genre>();
            //film.Genre.ForEach(x =>
            //{
            //    Genres.Add(data.Genres.GetById(x.Id));
            //});
            //Film.genre = Genres;
            //data.Films.Update(Film);
            data.Save();
        }

        public string CheckConnection()
        {
            return "Connection OK!";
        }

        public void DeleteFilm(int id)
        {
            var film = data.Films.GetById(id);
            data.Films.Delete(film);
            data.Save();
        }

        public FilmContract GetFilmById(int id)
        {
            return data.Films.GetById(id);
        }

        public List<GenreContract> GetGenres()
        {
            return data.Genres.GetAll().Select(x => (GenreContract)x).ToList();
        }

        public List<FilmContract> GetFilms()
        {

            return data.Films.GetAll().Select(x => (FilmContract)x).ToList();

        }

    }
}
