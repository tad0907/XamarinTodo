using System;
using System.Collections.Generic;
using System.Text;
using XamarinTodo.Domain.Models.Todos;

namespace XamarinTodo.SQLite.Persistents.Todos
{
    public class TodoFactory : ITodoFactory
    {
        public Todo Create(TodoTitle title, TodoDeadline deadline)
        {
            var id = new TodoId(Guid.NewGuid().ToString());
            var isCompleted = new TodoIsCompleted(false);
            return new Todo(id, title, deadline, isCompleted);
        }
    }
}
