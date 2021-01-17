using System;
using System.Collections.Generic;
using System.Text;
using XamarinTodo.Domain.Models.Todos;
using XamarinTodo.InMemory.Foundation;

namespace XamarinTodo.InMemory.Persistence.Todos
{
    public class InMemoryTodoFactory : ITodoFactory
    {
        public InMemoryTodoFactory()
        {
        }

        public Todo Create(TodoTitle title, TodoDeadline deadline)
        {
            var id = new TodoId(Guid.NewGuid());
            var isCompleted = new TodoIsCompleted(false);

            return new Todo(id, title, deadline, isCompleted);
        }
    }
}
