using FilmsDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class BizFilm
    {
        public int Id { get; set; }

        [StringLength(120)]
        public string Title { get; set; }

        public int DirectorID { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }

        [StringLength(300)]
        public string PhotoName { get; set; }

        public string Description { get; set; }

        public List<BizGenre> Genre { get; set; }

    }
}
