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
    public interface ITestFilmData
    {
        [OperationContract]
        string CheckConnection();

        [OperationContract]
        List<FilmContract> GetFilms();

        [OperationContract]
        void AddOrUpdateFilm(FilmContract film);

        [OperationContract]
        void DeleteFilm(int id);

        [OperationContract]
        FilmContract GetFilmById(int id);

        [OperationContract]
        List<GenreContract> GetGenres();

    }


    
}
