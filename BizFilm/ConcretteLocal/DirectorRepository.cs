using FilmsDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ConcretteLocal
{
    public class DirectorRepository : GeneralRepository<director>
    {
        public DirectorRepository(FilmDB context) : base(context)
        {

        }
    }
}
