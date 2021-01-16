using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.Domain.Models.Todos
{
    public interface ITodoRepository
    {
        void Delete(Todo todo);
        Todo Find(TodoId id);
        List<Todo> FindAll();
        void Save(Todo todo);
    }
}
