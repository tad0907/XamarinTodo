using System;
using System.Collections.Generic;
using System.Text;
using XamarinTodo.Domain.Models.Todos;

namespace XamarinTodo.Domain.Services
{
    public class TodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
    }
}
