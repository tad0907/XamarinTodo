using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using XamarinTodo.Domain.Models.Todos;
using XamarinTodo.Domain.Services;
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

        public TodoSaveResult Save(TodoSaveCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                if (command.Title.Length > 20)
                    throw new Exception("タイトルは２０文字以下で入力してください。");

                var title = new TodoTitle(command.Title);
                var deadline = new TodoDeadline(command.Deadline);

                var Todo = _todoFactory.Create(title, deadline);

                _todoRepository.Save(Todo);

                transaction.Complete();

                return new TodoSaveResult(Todo.Id.Value);
            }
        }
    }
}
