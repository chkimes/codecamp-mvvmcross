using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using MvvmCross.Demo.ViewModels.ViewModels;
using ObjCRuntime;
using UIKit;

namespace MvvmCross.Demo.UI.iOS.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView { BackgroundColor = UIColor.White };
            base.ViewDidLoad();

			// ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
               EdgesForExtendedLayout = UIRectEdge.None;

            var textField = new UITextField(new CGRect(10, 10, 240, 40));
            Add(textField);

            var button = UIButton.FromType(UIButtonType.System);
            button.Frame = new CGRect(260, 10, 50, 40);
            button.SetTitle("Search", UIControlState.Normal);
            Add(button);

            var table = new UITableView(new CGRect(0, 50, 320, 430));
            Add(table);
            var source = new MvxStandardTableViewSource(table, "TitleText Title");
            table.Source = source;

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(textField).To(vm => vm.MovieName);
            set.Bind(button).To(vm => vm.UpdateCommand);
            set.Bind(source).To(vm => vm.FoundMovies);
            set.Apply();

            View.AddGestureRecognizer(new UITapGestureRecognizer(() => textField.ResignFirstResponder()) {CancelsTouchesInView = false});
        }
    }
}