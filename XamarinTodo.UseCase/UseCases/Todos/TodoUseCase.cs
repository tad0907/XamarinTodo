using System;
using System.Collections.Generic;
using System.Text;
using XamarinTodo.Domain.Models.Todos;
using XamarinTodo.Domain.Services;

namespace XamarinTodo.UseCase.UseCases.Todos
{
    public class TodoUseCase
    {
        private readonly ITodoFactory _todoFactory;
        private readonly ITodoRepository _todoRepository;
        private readonly TodoService _todoService;


        public TodoUseCase(ITodoFactory todoFactory, ITodoRepository todoRepository, TodoService todoService)
        {
            _todoFactory = todoFactory;
            _todoRepository = todoRepository;
            _todoService = todoService;
        }
    }
}
