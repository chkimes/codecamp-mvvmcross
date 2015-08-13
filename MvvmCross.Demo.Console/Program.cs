using System;
using System.Net.Http;
using System.Threading.Tasks;
using MvvmCross.Demo.Core;
using MvvmCross.Demo.Shared;

namespace MvvmCross.Demo.Console
{
    class Program
    {
        static void Main()
        {
            AsyncMain().Wait();
        }

        static async Task AsyncMain()
        {
            var omdbApi = new OmdbApi(new SharedHttpClient());

            while (true)
            {
                System.Console.WriteLine("SEARCH for a movies or get by ID:");
                var input = System.Console.ReadLine();
                if (string.IsNullOrEmpty(input)) return;

                switch (input.ToLower().Split(' ')[0])
                {
                    case "exit":
                    case "":
                    case null:
                        return;
                    case "search":
                        await Search(omdbApi, input.Split(' ')[1]);
                        break;
                    case "id":
                        await ById(omdbApi, input.Split(' ')[1]);
                        break;
                }
            }
        }

        private static async Task ById(OmdbApi omdbApi, string s)
        {
            var movie = await omdbApi.GetById(s);
            if (!string.IsNullOrEmpty(movie.Error))
            {
                System.Console.WriteLine(movie.Error);
                return;
            }

            foreach (var prop in movie.GetType().GetProperties())
            {
                System.Console.WriteLine(prop.Name + ": " + prop.GetMethod.Invoke(movie, new object[]{})); // I'm lazy
            }
        }

        private static async Task Search(OmdbApi omdbApi, string s)
        {
            var results = await omdbApi.Search(s);
            if (!string.IsNullOrEmpty(results.Error))
            {
                System.Console.WriteLine(results.Error);
                return;
            }

            foreach (var movie in results.Search)
                System.Console.WriteLine($"{movie.ImdbId}: {movie.Title} ({movie.Year})");
        }
    }
}
