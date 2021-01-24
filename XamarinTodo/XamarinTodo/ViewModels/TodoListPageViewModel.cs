using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinTodo.UseCase.UseCases.Todos;

namespace XamarinTodo.ViewModels
{
    public class TodoListPageViewModel : ViewModelBase
    {
        private TodoUseCase _useCase;

        public TodoListPageViewModel(INavigationService navigationService)
                   : base(navigationService)
        {

        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            var result = _useCase.GetAll();
        }

        public List<TodoListPageViewModelTodo> Todos { get; private set; }
    }
}
