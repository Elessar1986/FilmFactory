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
using Repository.Abstract;
using AutoMapper;
using FilmsDB.Model;

namespace TestService
{

    public class FilmDataService : IFilmDataService
    {

        IUnitOfWork data = new UnitOfWork("ModelFilmTest");

        public FilmDataService()
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
            FilmContract film = data.Films.GetById(id);
            film.DirectorName = data.Director.GetById(film.DirectorId).Director1;
            return film;
        }

        public List<GenreContract> GetGenres()
        {
            return data.Genres.GetAll().Select(x => (GenreContract)x).ToList();
        }

        public List<FilmContract> GetFilms()
        {
            List<FilmContract> films = data.Films.GetAll().Select(x => (FilmContract)x).ToList();
            films.ForEach( x => x.DirectorName = data.Director.GetById(x.DirectorId).Director1);
            return films;

        }

        public void AddGenre(GenreContract genre)
        {
            data.Genres.Create((genre)genre);
            data.Save();
        }

        public void UpdateGenre(GenreContract genre)
        {
            data.Genres.Update((genre)genre);
            data.Save();
        }

        public void DeleteGenre(int id)
        {
            var genre = data.Genres.GetById(id);
            data.Genres.Delete(genre);
            data.Save();
        }

        public GenreContract GetGenreById(int id)
        {
            return data.Genres.GetById(id);
        }

        public List<DirectorContract> GetDirector()
        {
            return data.Director.GetAll().Select(x => (DirectorContract)x).ToList();
        }

        public void AddDirector(DirectorContract director)
        {
            data.Director.Create((director)director);
            data.Save();
        }

        public void UpdateDirector(DirectorContract director)
        {
            data.Director.Update((director)director);
            data.Save();
        }

        public void DeleteDirector(int id)
        {
            var director = data.Director.GetById(id);
            data.Director.Delete(director);
            data.Save();
        }

        public DirectorContract GetDirectorById(int id)
        {
            return data.Director.GetById(id);
        }

        public List<FilmContract> GetTop20Films()
        {
            var films = data.Films.GetAll().Select(x => (FilmContract)x).OrderByDescending(x => x.Rate).Take(20).ToList();
            return films;
        }
    }
}
