using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TestService.DataContract
{

    [DataContract]
    public class DirectorContract
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Director { get; set; }

        public static implicit operator DirectorContract(FilmsDB.TestModel.director g)
        {
            return
                new DirectorContract()
                {
                    Director = g.Director1,
                    Id = g.Id
                };
        }

        public static explicit operator FilmsDB.TestModel.director(DirectorContract g)
        {
            return
                new FilmsDB.TestModel.director()
                {
                    Director1 = g.Director,
                    Id = g.Id
                };
        }
    }
}