namespace FilmsDB.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelFilmTest : DbContext
    {
        public ModelFilmTest()
            : base("name=ModelFilmTest")
        {
        }

        public virtual DbSet<director> director { get; set; }
        public virtual DbSet<films> films { get; set; }
        public virtual DbSet<genre> genre { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<films>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<films>()
                .HasMany(e => e.genre)
                .WithMany(e => e.films)
                .Map(m => m.ToTable("film_genre").MapLeftKey("FilmId").MapRightKey("GenreId"));
        }
    }
}
