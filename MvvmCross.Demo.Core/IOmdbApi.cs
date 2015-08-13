using System.Threading.Tasks;

namespace MvvmCross.Demo.Core
{
    public interface IOmdbApi
    {
        Task<SearchResults> Search(string name);
        Task<Movie> GetById(string imdbId);
    }
}