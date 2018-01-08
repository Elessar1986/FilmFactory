using FilmsDB.TestModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
//using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrette
{
    public class FilmRepository : GeneralRepositiry<films>
    {



        public FilmRepository(ModelFilmTest context) : base(context)
        {
        }
    }

}
