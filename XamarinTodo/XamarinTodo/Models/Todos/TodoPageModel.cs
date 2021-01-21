using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.Models.Todos
{
    public class TodoPageModel
    {
        public TodoPageModel()
        {

        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime? Deadline { get; set; }

        public bool IsCompleted { get; set; }
    }
}
