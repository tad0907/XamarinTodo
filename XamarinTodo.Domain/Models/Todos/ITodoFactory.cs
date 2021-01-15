using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.Domain.Models.Todos
{
    public interface ITodoFactory
    {
        Todo Create(TodoTitle title, TodoDeadline deadline);
    }
}
