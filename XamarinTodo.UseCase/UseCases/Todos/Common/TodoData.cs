using System;
using System.Collections.Generic;
using System.Text;
using XamarinTodo.Domain.Models.Todos;

namespace XamarinTodo.UseCase.UseCases.Todos.Common
{
    public class TodoData
    {
        public TodoData(Todo source)
            : this(source.Id.Value, source.Title.Value, source.Deadline.Value, source.IsCompleted.Value)
        {
        }

        public TodoData(string id, string title, DateTime? deadline, bool isCompleted)
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
