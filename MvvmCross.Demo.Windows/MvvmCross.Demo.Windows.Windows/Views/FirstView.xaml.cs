using Windows.UI.Xaml.Controls;
using Cirrious.MvvmCross.WindowsCommon.Views;
using MvvmCross.Demo.ViewModels.ViewModels;

namespace MvvmCross.Demo.Windows.Views
{
    public sealed partial class FirstView : MvxWindowsPage
    {
        public FirstView()
        {
            this.InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                ((FirstViewModel)ViewModel).ItemSelectedCommand.Execute(e.AddedItems[0]);
                ((ListView) sender).SelectedIndex = -1;
            }
        }
    }
}
