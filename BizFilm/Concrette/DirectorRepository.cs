using FilmsDB.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrette
{
    public class DirectorRepository : GeneralRepositiry<director>
    {
        public DirectorRepository(ModelFilmTest context) : base(context)
        {

        }
    }
}
