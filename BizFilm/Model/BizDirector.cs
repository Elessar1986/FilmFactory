﻿using FilmsDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class BizDirector
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Director { get; set; }

    }
}
