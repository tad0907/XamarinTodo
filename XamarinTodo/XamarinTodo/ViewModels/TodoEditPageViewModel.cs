using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinTodo.UseCase.UseCases.Todos;

namespace XamarinTodo.ViewModels
{
    public class TodoEditPageViewModel : ViewModelBase
    {
        private TodoUseCase _useCase;

        public TodoEditPageViewModel(INavigationService navigationService, TodoUseCase useCase)
                   : base(navigationService)
        {
            _useCase = useCase;
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
        }
    }
}
