using System;
using System.Collections.Generic;
using System.Text;
using XamarinTodo.UseCase.UseCases.Todos.Common;

namespace XamarinTodo.UseCase.UseCases.Todos.GetAll
{
    public class TodoGetAllResult
    {
        public TodoGetAllResult(List<TodoData> todos)
        {
            Todos = todos;
        }

        public List<TodoData> Todos { get; }
    }
}
