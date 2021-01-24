using Prism.Navigation;
using System;
using XamarinTodo.UseCase.UseCases.Todos.Common;

namespace XamarinTodo.ViewModels
{
    public class TodoListPageViewModelTodo
    {
        public TodoListPageViewModelTodo(TodoData source)
            : this(source.Id, source.Title, source.Deadline, source.IsCompleted)
        {
        }

        public TodoListPageViewModelTodo(Guid id, string title, DateTime? deadline, bool isCompleted)
        {
            Id = id;
            Title = title;
            Deadline = deadline;
            IsCompleted = isCompleted;
        }

        public Guid Id { get; }
        public string Title { get; }
        public DateTime? Deadline { get; }
        public bool IsCompleted { get; }
    }
}