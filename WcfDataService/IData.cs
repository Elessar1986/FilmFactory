using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Films.DOL.Model;


namespace WcfDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IData
    {
        [OperationContract]
        string ConnectionTest();


        [OperationContract]
         IEnumerable<film> GetFilms();



        [OperationContract]
        void AddFilm(film film);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
   
}
