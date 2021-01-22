using System;
using System.Collections.Generic;
using System.Text;
using XamarinTodo.Models.Common;

namespace XamarinTodo.Models.Todos
{
    public class TodoPageModel : PageModelBase
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
