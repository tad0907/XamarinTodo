using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace XamarinTodo.Domain.Models.Todos
{
    public interface ITodoRepository
    {
        void Delete(Todo todo);
        Todo Find(TodoId id);
        Todo Find(TodoTitle title);
        List<Todo> List(Func<Todo, bool> condition);
        List<Todo> List();
        void Save(Todo todo);
    }
}
