using System;
using System.Collections.Generic;
using System.Text;
using XamarinTodo.UseCase.UseCases.Todos.Common;

namespace XamarinTodoNotPrism.Models.Todos
{
    public class TodoListPageModelTodo
    {
        public TodoListPageModelTodo(TodoData source)
            : this(source.Id, source.Title, source.Deadline, source.IsCompleted)
        {
        }

        public TodoListPageModelTodo(string id, string title, DateTime? deadline, bool isCompleted)
        {
            Id = id;
            Title = title;
            Deadline = deadline;
            IsCompleted = isCompleted;
        }

        public string Id { get; }
        public string Title { get; }
        public DateTime? Deadline { get; }
        public bool IsCompleted { get; }
    }
}
