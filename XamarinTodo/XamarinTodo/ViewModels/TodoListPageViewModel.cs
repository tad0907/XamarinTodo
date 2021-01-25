using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XamarinTodo.UseCase.UseCases.Todos;

namespace XamarinTodo.ViewModels
{
    public class TodoListPageViewModel : ViewModelBase
    {
        private TodoUseCase _useCase;

        public TodoListPageViewModel(INavigationService navigationService, TodoUseCase useCase)
                   : base(navigationService)
        {
            _useCase = useCase;

            ToTodoCreatePageButton = new DelegateCommand(ToTodoCreatePage);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            var result = _useCase.GetAll();
            result.Todos.ForEach(x => Todos.Add(new TodoListPageViewModelTodo(x)));
        }

        private ObservableCollection<TodoListPageViewModelTodo> _todos
            = new ObservableCollection<TodoListPageViewModelTodo>();
        public ObservableCollection<TodoListPageViewModelTodo> Todos 
        {
            get { return _todos; }
            set
            {
                SetProperty(ref _todos, value);
            }
        }

        public DelegateCommand ToTodoCreatePageButton { get; set; }

        public async void ToTodoCreatePage()
        {
            await NavigationService.NavigateAsync("NavigationPage/TodoCreatePage");
        }
    }
}
