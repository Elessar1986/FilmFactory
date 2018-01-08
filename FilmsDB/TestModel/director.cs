namespace FilmsDB.TestModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("director")]
    public partial class director
    {
        public int Id { get; set; }

        [Column("Director")]
        [StringLength(50)]
        public string Director1 { get; set; }
    }
}
