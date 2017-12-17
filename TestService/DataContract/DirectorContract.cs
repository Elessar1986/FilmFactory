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


    }
}