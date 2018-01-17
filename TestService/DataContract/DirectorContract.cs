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

        public static implicit operator DirectorContract(FilmsDB.Model.director g)
        {
            return
                new DirectorContract()
                {
                    Director = g.Director1,
                    Id = g.Id
                };
        }

        public static explicit operator FilmsDB.Model.director(DirectorContract g)
        {
            return
                new FilmsDB.Model.director()
                {
                    Director1 = g.Director,
                    Id = g.Id
                };
        }
    }
}