using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinTodo.Domain.Models.Todos;
using XamarinTodo.SQLite.Contexts;
using XamarinTodo.SQLite.Models;
using XamarinTodo.SQLite.Persistence.Common;

namespace XamarinTodo.SQLite.Persistence.Todos
{
    public class TodoFactory : SimpleIncrementalFactory<TodoDataModel>, ITodoFactory
    {
        public TodoFactory(LocalDbContext context)
            : base(context)
        {
        }

        public Todo Create(TodoTitle title, TodoDeadline deadline)
        {
            var id = AssignNumber();
            var isCompleted = false;

            return new Todo(
                new TodoId(id),
                title,
                deadline,
                new TodoIsCompleted(isCompleted));
        }

        protected override int IdToInt(TodoDataModel data)
        {
            return Convert.ToInt32(data.Id);
        }

        protected override DbSet<TodoDataModel> GetDbSet(LocalDbContext context)
        {
            return context.Todos;
        }
    }
}
