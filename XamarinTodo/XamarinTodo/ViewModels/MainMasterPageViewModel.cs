using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinTodo.UseCase.UseCases.Todos;
using XamarinTodo.Views;

namespace XamarinTodo.ViewModels
{
    public class MainMasterPageViewModel : BindableBase
    {
        public MainMasterPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        private INavigationService NavigationService { get; }

        public ObservableCollection<MenuPageViewModel> MenuItems { get; } 
            = new ObservableCollection<MenuPageViewModel>
        {
            new MenuPageViewModel("Today", "TodoListPage", "Sun", "LightPink"),
            new MenuPageViewModel("Importance", "TodoListPage", "MtFuji", "Red")
        };


        private bool isPresented;

        public bool IsPresented
        {
            get => isPresented;
            set => SetProperty(ref isPresented, value);
        }

        public async Task PageChangeAsync(MenuPageViewModel menu)
        {
            await NavigationService.NavigateAsync($"/{nameof(MainMasterPage)}/NavigationPage/{menu.PageName}");
            IsPresented = false;
        }
    }
}