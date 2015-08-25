using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using MvvmCross.Demo.Core;

namespace MvvmCross.Demo.ViewModels.ViewModels
{
    public class MovieViewModel : MvxViewModel
    {
        private readonly IOmdbApi _api;

        public MovieViewModel(IOmdbApi api)
        {
            _api = api;
        }

        public async void Init(string id)
        {
            Movie = await _api.GetById(id);
        }

        private Movie _movie;
        public Movie Movie
        {
            get { return _movie; }
            set { _movie = value; RaisePropertyChanged(); }
        }

        public ICommand CloseCommand => new MvxCommand(() => Close(this));
    }
}