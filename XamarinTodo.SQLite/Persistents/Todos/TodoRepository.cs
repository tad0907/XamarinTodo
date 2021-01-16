using System;
using System.Collections.Generic;
using System.Text;
using XamarinTodo.Domain.Models.Todos;

namespace XamarinTodo.SQLite.Persistents.Todos
{
    public class TodoRepository : ITodoRepository
    {
        public void Delete(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Todo Find(TodoId id)
        {
            throw new NotImplementedException();
        }

        public List<Todo> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
