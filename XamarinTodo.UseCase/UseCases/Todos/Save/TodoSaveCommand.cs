using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.UseCase.UseCases.Todos.Save
{
    public class TodoSaveCommand
    {

        public TodoSaveCommand(string title, DateTime? deadline)
        {
            Title = title;
            Deadline = deadline;
        }

        public string Title { get; }

        public DateTime? Deadline { get; }
    }
}
