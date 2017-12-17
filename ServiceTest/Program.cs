using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceTest;

namespace ServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FilmData.TestFilmDataClient testFilmDataClient = new FilmData.TestFilmDataClient();

            Console.WriteLine(testFilmDataClient.CheckConnection());

            var films = testFilmDataClient.GetFilms().ToList();
            var genres = testFilmDataClient.GetGenres().ToList();

            foreach (var item in films)
            {
                Console.WriteLine($"1: {item.Id} \n" +
                    $"2: {item.DirectorId} \n" +
                    $"3: {item.Title} \n" +
                    $"4: {item.Year} \n" +
                    $"5: {item.Rate}");
                foreach (var i in item.Genre)
                {
                    Console.WriteLine($"\tG: {i.GenreName}");
                }
            }

            var g = new List<FilmData.GenreContract>();
            g.Add(genres[0]);
            g.Add(genres[2]);


            //testFilmDataClient.AddFilm(new FilmData.FilmContract()
            //{
            //    Title = "Film for testing DB",
            //    Description = "akjdkajshdkjd naksjdkajsdh aksjdhaksjdh",
            //    DirectorId = 2,
            //    PhotoName = "asdfg.jpg",
            //    Rate = 3.2,
            //    Year = 2015,
            //    Genre = g.ToArray()

            //});

            var f = films[1];
            f.Title = "New Film 1111";
            f.Description = "qweqwe qweqwe qweqwe";
            f.Genre = g.ToArray();

            testFilmDataClient.UpdateFilm(f);

            //testFilmDataClient.DeleteFilm(f.Id);

            Console.WriteLine("Done!");

            Console.ReadKey();
        }

    }
}
