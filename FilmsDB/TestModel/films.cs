namespace FilmsDB.TestModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class films
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public films()
        {
            genre = new HashSet<genre>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Title { get; set; }

        public int DirectorID { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }

        [StringLength(300)]
        public string PhotoName { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<genre> genre { get; set; }
    }
}
