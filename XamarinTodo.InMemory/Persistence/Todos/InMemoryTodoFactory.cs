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
        public SerialNumberAssigner NumberAssigner { get; } = new SerialNumberAssigner();

        public Todo Create(TodoTitle title, TodoDeadline deadline)
        {
            var rawId = NumberAssigner.Next();
            var isCompleted = new TodoIsCompleted(false);

            return new Todo(new TodoId(rawId.ToString()), title, deadline, isCompleted);
        }
    }
}
