using FilmsDB.Model;
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

        //FilmDB context;

        public FilmRepository(FilmDB context) : base(context) 
        {
            //this.context = context;
        }

        //public override void Update(films film)
        //{
            

        //    context.SaveChanges();
        //}
    }
}
