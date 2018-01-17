﻿using FilmsDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrette
{
    public class GenreRepository : GeneralRepository<genre>
    {
        public GenreRepository(FilmDB context) : base(context) { }
    }
}
