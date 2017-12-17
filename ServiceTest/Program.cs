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

            //Console.WriteLine(testFilmDataClient.CheckConnection());

            //var test = testFilmDataClient.GetFilms();

            //foreach (var item in test)
            //{
            //    Console.WriteLine($"1: {item.Id} \n" +
            //        $"2: {item.DirectorId} \n" +
            //        $"3: {item.Title} \n" +
            //        $"4: {item.Year} \n" +
            //        $"5: {item.Rate}");
            //    foreach (var i in item.Genre)
            //    {
            //        Console.WriteLine($"\tG: {i.GenreName}");
            //    }
            //}

            var test12 = testFilmDataClient.GetGenres();

            foreach (var item in test12)
            {
                Console.WriteLine($"1: {item.Id} \n" +
                    $"2: {item.GenreName} \n");

            }

            //var test1 = testFilmDataClient.GetFilmById(3);

            //Console.WriteLine($"1: {test1.Id} \n" +
            //        $"2: {test1.DirectorId} \n" +
            //        $"3: {test1.Title} \n" +
            //        $"4: {test1.Year} \n" +
            //        $"5: {test1.Rate}");
            //foreach (var i in test1.Genre)
            //{
            //    Console.WriteLine($"\tG: {i.GenreName}");
            //}

            var g = new List<FilmData.GenreContract>();
            g.Add(test12[3]);
            g.Add(test12[4]);

            //test[2].Title = "Ererererererererer test";
            //test[2].Genre

            testFilmDataClient.AddOrUpdateFilm(new FilmData.FilmContract()
            {
                Title = "Test12345",
                DirectorId = 1,
                Description = "test test test 12345",
                Rate = 7.2,
                Year = 1234,
                Genre = g.ToArray(),
                //Id = 2
            });

            //int test2 = testFilmDataClient.AddFilm(test[2]);

            //Console.WriteLine("ID = " + test2);

            Console.ReadKey();
        }

    }
}
