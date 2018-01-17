using FilmsDB.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ConcretteLocal
{
    public class GenreRepository : GeneralRepository<genre>
    {
        public GenreRepository(FilmDB context) : base(context) { }
    }
}
