using FilmsDB.TestModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
//using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ConcretteLocal
{
    public class FilmRepository : GeneralRepository<films>
    {



        public FilmRepository(FilmDB context) : base(context)
        {
        }
    }

}
