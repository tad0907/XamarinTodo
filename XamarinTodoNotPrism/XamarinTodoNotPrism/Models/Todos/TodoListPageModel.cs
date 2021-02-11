using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinTodo.UseCase.UseCases.Todos;

namespace XamarinTodoNotPrism.Models.Todos
{
    public class TodoListPageModel
    {
        private TodoUseCase _useCase;

        public TodoListPageModel(TodoUseCase useCase)
        {
            _useCase = useCase;
        }

        public ObservableCollection<TodoListPageModelTodo> Todos{ get; private set; }

        public void Initialize()
        {
            var result = _useCase.GetAll();
            result.Todos.ForEach(x => Todos.Add(new TodoListPageModelTodo(x)));
        }
    }
}
