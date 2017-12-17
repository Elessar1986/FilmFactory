using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TestService.DataContract;

namespace TestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestFilmData" in both code and config file together.
    [ServiceContract]
    public interface IFilmDataService
    {
        [OperationContract]
        string CheckConnection();

        [OperationContract]
        List<FilmContract> GetFilms();

        [OperationContract]
        void AddFilm(FilmContract film);

        [OperationContract]
        void UpdateFilm(FilmContract film);

        [OperationContract]
        void DeleteFilm(int id);

        [OperationContract]
        FilmContract GetFilmById(int id);

        [OperationContract]
        List<GenreContract> GetGenres();

        [OperationContract]
        void AddGenre(GenreContract genre);

        [OperationContract]
        void UpdateGenre(GenreContract genre);

        [OperationContract]
        void DeleteGenre(int id);

        [OperationContract]
        GenreContract GetGenreById(int id);

        [OperationContract]
        List<DirectorContract> GetDirector();

        [OperationContract]
        void AddDirector(DirectorContract director);

        [OperationContract]
        void UpdateDirector(DirectorContract director);

        [OperationContract]
        void DeleteDirector(int id);

        [OperationContract]
        DirectorContract GetDirectorById(int id);

    }


    
}
