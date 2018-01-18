using FilmFactory.Environment.DataMapper;
using FilmFactory.FilmsData;
using FilmFactory.Models.Film;
using FilmFactory.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFactory.Helpers
{
    public class FindingEngine
    {
        List<FilmViewModel> findResult;

        public FindingEngine()
        {
            findResult = new List<FilmViewModel>();
        }

        public List<FilmViewModel> Find (FindFilter filter, FilmDataServiceClient client)
        {

            var filmsByDir = client.FindFilmByDirector(filter.DirectorId).Where(x => x.Rate >= filter.Rate).Where(x => x.Year >= filter.Year).ToList();
            if (filter.GenreId <= 0) return filmsByDir.Select(y => FilmDataMapper.getFilmViewModel(y)).ToList();

            var filmsByGenre = client.FindFilmByGenre(filter.GenreId).Where(x => x.Rate >= filter.Rate).Where(x => x.Year >= filter.Year).ToList();
            if (filter.DirectorId <= 0) return filmsByGenre.Select(y => FilmDataMapper.getFilmViewModel(y)).ToList();

            List<FilmViewModel> films = filmsByDir.Where(x => filmsByGenre.Any(a => a.Id == x.Id)).Select(y => FilmDataMapper.getFilmViewModel(y)).ToList();
            return films;
        }

    }
}