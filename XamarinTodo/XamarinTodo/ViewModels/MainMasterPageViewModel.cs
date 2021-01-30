using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinTodo.ViewModels
{
    public class MainMasterPageViewModel : ViewModelBase
    {

        public MainMasterPageViewModel(INavigationService navigationService)
                   : base(navigationService)
        {
        }

        private ObservableCollection<MainMasterPageViewModelMenu> _menus
            = new ObservableCollection<MainMasterPageViewModelMenu>();

        public ObservableCollection<MainMasterPageViewModelMenu> Menus
        {
            get => _menus;
            set => SetProperty(ref _menus, value);
        }
        public Command<MainMasterPageViewModelMenu> ItemSelectedCommand;

        private bool isPresented;

        public bool IsPresented
        {
            get => isPresented;
            set => SetProperty(ref isPresented, value);
        }

        public async override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Menus.Add(new MainMasterPageViewModelMenu("タスク一覧", "TaskListPage"));

            await NavigationService.NavigateAsync($"NavigationPage/TaskListPage");
            IsPresented = false;
        }

        public async void ItemSelected(MainMasterPageViewModelMenu menu)
        {
            await NavigationService.NavigateAsync($"NavigationPage/{menu.PageName}");
            IsPresented = false;
        }
    }
}