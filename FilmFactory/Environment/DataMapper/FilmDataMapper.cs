using FilmFactory.FilmsData;
using FilmFactory.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFactory.Environment.DataMapper
{
    public class FilmDataMapper
    {
        public static FilmContract getFilmContract (FilmViewModel data, string fileName)
        {
            var genres = new List<GenreContract>();
            foreach (var item in data.Genre)
            {
                genres.Add(new GenreContract() { Id = item });
            }
            var newFilm = new FilmContract()
            {
                Id = data.Id,
                Description = data.Description,
                Rate = data.Rate,
                DirectorId = data.DirectorId,
                PhotoName = fileName,
                Title = data.Title,
                Year = data.Year,
                Genre = genres.ToArray()
            };

            return newFilm;
        }


        public static FilmViewModel getFilmViewModel (FilmContract film)
        {
            var filmVM = new FilmViewModel()
            {
                Id = film.Id,
                Title = film.Title,
                DirectorId = film.DirectorId,
                Description = film.Description,
                Genre = film.Genre.Select(x => x.Id).ToArray(),
                Rate = film.Rate,
                Year = film.Year
            };

            return filmVM;

        }

    }
}