using System.Collections.Generic;

namespace MvvmCross.Demo.Core
{
    public class SearchResults
    {
        public List<MovieSlim> Search { get; set; }
        public string Error { get; set; }
    }
}