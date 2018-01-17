using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Repository.UnitOnWork;


namespace TestService.DataContract
{

    [DataContract]
    public class FilmContract
    {


        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int DirectorId { get; set; }
        [DataMember]
        public string DirectorName { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public double Rate { get; set; }
        [DataMember]
        public string PhotoName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public List<GenreContract> Genre { get; set; }


        public static implicit operator FilmContract(FilmsDB.Model.films f)
        {
            return
                new FilmContract()
                {
                    Description = f.Description,
                    DirectorId = f.DirectorID,
                    Id = f.Id,
                    Year = f.Year,
                    Title = f.Title,
                    Rate = f.Rate,
                    PhotoName = f.PhotoName,
                    Genre = f.genre.Select(y => new GenreContract()
                    {
                        GenreName = y.Genre1,
                        Id = y.Id
                    }).ToList()
                };
        }

        public static explicit operator FilmsDB.Model.films(FilmContract f)
        {
            return
                new FilmsDB.Model.films()
                {
                    Description = f.Description,
                    DirectorID = f.DirectorId,
                    Id = f.Id,
                    Year = f.Year,
                    Title = f.Title,
                    Rate = f.Rate,
                    PhotoName = f.PhotoName
                    ,
                    genre = f.Genre.Select(y => new FilmsDB.Model.genre()
                    {
                        Genre1 = y.GenreName,
                        Id = y.Id
                    }).ToList()
                };
        }
    }
}