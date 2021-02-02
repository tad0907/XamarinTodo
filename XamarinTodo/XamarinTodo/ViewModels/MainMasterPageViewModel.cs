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
    public class MainMasterPageViewModel : ViewModelBase
    {
        private TodoUseCase _useCase;

        public MainMasterPageViewModel(INavigationService navigationService, TodoUseCase useCase)
                   : base(navigationService)
        {
            _useCase = useCase;

            DisplayTodayCommand = new DelegateCommand(DisplayToday);
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

            Menus.Add(new MainMasterPageViewModelMenu("Today", "TaskListPage", "LightPink"));
            Menus.Add(new MainMasterPageViewModelMenu("Importance", "TaskListPage", "Red"));

            await NavigationService.NavigateAsync($"NavigationPage/TaskListPage");
            IsPresented = false;
        }

        public DelegateCommand DisplayTodayCommand { get; set; }

        public async void DisplayToday()
        {
            await NavigationService.NavigateAsync($"{nameof(TodoCreatePage)}");
        }
    }
}