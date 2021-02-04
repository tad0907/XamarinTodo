using Xamarin.Forms;
using XamarinTodo.ViewModels;

namespace XamarinTodo.Views
{
    public partial class MenuPage : ContentPage
    {
        private MainMasterPageViewModel ViewModel => this.BindingContext as MainMasterPageViewModel;

        public MenuPage()
        {
            InitializeComponent();
        }

        private async void ListViewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await ViewModel.PageChangeAsync(e.SelectedItem as MenuPageViewModel);
        }
    }
}
