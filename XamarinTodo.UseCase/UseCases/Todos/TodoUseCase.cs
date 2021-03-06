﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using XamarinTodo.Domain.Models.Todos;
using XamarinTodo.Domain.Services;
using XamarinTodo.UseCase.UseCases.Todos.Common;
using XamarinTodo.UseCase.UseCases.Todos.GetAll;
using XamarinTodo.UseCase.UseCases.Todos.Save;

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

        public TodoGetAllResult GetAll()
        {
            var todos = _todoRepository.List();
            return new TodoGetAllResult(todos.Select(x => new TodoData(x)).ToList());
        }

        public TodoGetAllResult GetToday()
        {
            var today = DateTime.Today;
            var todos = _todoRepository.List(new Func<Todo, bool>(todo => todo.Deadline == new TodoDeadline(today)));
            return new TodoGetAllResult(todos.Select(x => new TodoData(x)).ToList());
        }

        public TodoSaveResult Save(TodoSaveCommand command)
        {
            var title = new TodoTitle(command.Title);
            var deadline = new TodoDeadline(command.Deadline);

            var Todo = _todoFactory.Create(title, deadline);

            _todoRepository.Save(Todo);

            return new TodoSaveResult(Todo.Id.Value);
        }
    }
}
