using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TestService.DataContract
{
    [DataContract]
    public class GenreContract
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string GenreName { get; set; }

        //public static implicit operator GenreContract(Repository.Model.BizGenre g)
        //{
        //    return
        //        new GenreContract()
        //        {
        //            GenreName = g.Genre,
        //            Id = g.Id
        //        };
        //}

        //public static explicit operator Repository.Model.BizGenre(GenreContract g)
        //{
        //    return
        //        new Repository.Model.BizGenre()
        //        {
        //            Genre = g.GenreName,
        //            Id = g.Id
        //        };
        //}

        public static implicit operator GenreContract(FilmsDB.TestModel.genre g)
        {
            return
                new GenreContract()
                {
                    GenreName = g.Genre1,
                    Id = g.Id
                };
        }

        public static explicit operator FilmsDB.TestModel.genre(GenreContract g)
        {
            return
                new FilmsDB.TestModel.genre()
                {
                    Genre1 = g.GenreName,
                    Id = g.Id
                };
        }

    }
}