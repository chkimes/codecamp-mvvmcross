using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using MvvmCross.Demo.Core;

namespace MvvmCross.Demo.ViewModels.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private readonly IOmdbApi _api;

        public FirstViewModel(IOmdbApi api)
        {
            _api = api;
        }

        private string _movieName;
        public string MovieName
		{ 
			get { return _movieName; }
            set { _movieName = value; RaisePropertyChanged(); }
		}

        private List<MovieSlim> _foundMovies;
        public List<MovieSlim> FoundMovies
        {
            get { return _foundMovies; }
            set { _foundMovies = value; RaisePropertyChanged(); }
        }

        private async void Update()
        {
            var movies = await _api.Search(MovieName);
            FoundMovies = movies.Search;
        }

        public ICommand UpdateCommand => new MvxCommand(Update);
    }
}
