using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinTodo.UseCase.UseCases.Todos;
using XamarinTodo.UseCase.UseCases.Todos.Save;
using XamarinTodo.Views;

namespace XamarinTodo.ViewModels
{
    public class TodoCreatePageViewModel : ViewModelBase
    {
        private TodoUseCase _useCase;

        public TodoCreatePageViewModel(INavigationService navigationService, TodoUseCase useCase)
                   : base(navigationService)
        {
            _useCase = useCase;

            CreateButton = new DelegateCommand(Create);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private DateTime? _deadline;
        public DateTime? Deadline
        {
            get => _deadline;
            set => SetProperty(ref _deadline, value);
        }

        public DelegateCommand CreateButton { get; set; }

        public async void Create()
        {
            var command = new TodoSaveCommand(Title, Deadline);
            _useCase.Save(command);

            await NavigationService.NavigateAsync($"/{nameof(MainMasterPage)}/NavigationPage/{nameof(TodoListPage)}");
        }
    }
}
