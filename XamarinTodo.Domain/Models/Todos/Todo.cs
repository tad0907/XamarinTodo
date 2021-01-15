using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.Domain.Models.Todos
{
    public sealed class Todo
    {
        public Todo(TodoId id, TodoTitle title, TodoDeadline deadline, TodoIsCompleted isCompleted)
        {
            Id = id;
            Title = title;
            Deadline = deadline;
            IsCompleted = isCompleted;
        }

        public TodoId Id { get; }

        public TodoTitle Title { get; private set; }

        public TodoDeadline Deadline { get; private set; }

        public TodoIsCompleted IsCompleted { get; private set; }
    }
}
