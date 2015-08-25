using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using MvvmCross.Demo.ViewModels.ViewModels;
using ObjCRuntime;
using UIKit;

namespace MvvmCross.Demo.UI.iOS.Views
{
    [Register("MovieView")]
    public class MovieViewController : MvxViewController
    {
        public new MovieViewModel ViewModel
        {
            get { return (MovieViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public override void ViewDidLoad()
        {
            View = new UIView {BackgroundColor = UIColor.White};
            base.ViewDidLoad();

			// ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
               EdgesForExtendedLayout = UIRectEdge.None;

            var ySep = 30;
            var titleLabel = new UILabel(new CGRect(10, 10 + ySep*0, 100, ySep)) {Text = "Title"};
            Add(titleLabel);

            var yearLabel = new UILabel(new CGRect(10, 10 + ySep*1, 100, ySep)) {Text = "Year"};
            Add(yearLabel);

            var directorLabel = new UILabel(new CGRect(10, 10 + ySep*2, 100, ySep)) {Text = "Director"};
            Add(directorLabel);

            var actorsLabel = new UILabel(new CGRect(10, 10 + ySep*3, 100, ySep*3)) {Text = "Actors", Lines = 3};
            Add(actorsLabel);

            var plotLabel = new UILabel(new CGRect(10, 10 + ySep*6, 100, ySep*4)) {Text = "Plot", Lines = 6};
            Add(plotLabel);

            var title = new UILabel(new CGRect(110, 10 + ySep*0, 200, ySep));
            Add(title);

            var year = new UILabel(new CGRect(110, 10 + ySep*1, 200, ySep));
            Add(year);

            var director = new UILabel(new CGRect(110, 10 + ySep*2, 200, ySep));
            Add(director);

            var actors = new UILabel(new CGRect(110, 10 + ySep*3, 200, ySep*3)) {Lines = 3};
            Add(actors);

            var plot = new UILabel(new CGRect(110, 10 + ySep*6, 200, ySep*4)) {Lines = 6};
            Add(plot);

            var set = this.CreateBindingSet<MovieViewController, MovieViewModel>();

            set.Bind(title).To(vm => vm.Movie.Title);
            set.Bind(year).To(vm => vm.Movie.Year);
            set.Bind(director).To(vm => vm.Movie.Director);
            set.Bind(actors).To(vm => vm.Movie.Actors);
            set.Bind(plot).To(vm => vm.Movie.Plot);

            set.Apply();
        }
    }
}