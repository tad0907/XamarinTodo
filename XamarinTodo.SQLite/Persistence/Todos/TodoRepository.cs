using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinTodo.Domain.Models.Todos;
using XamarinTodo.SQLite.Contexts;
using XamarinTodo.SQLite.Models;

namespace XamarinTodo.SQLite.Persistence.Todos
{
    public class TodoRepository : ITodoRepository
    {
        private readonly LocalDbContext _context;

        public TodoRepository(LocalDbContext context)
        {
            _context = context;
        }

        public void Delete(Todo todo)
        {
            var target = _context.Todos.Find(todo.Id.Value);

            if (target == null)
            {
                return;
            }

            _context.Todos.Remove(target);

            _context.SaveChanges();
        }

        public Todo Find(TodoId id)
        {
            var target = _context.Todos.Find(id.Value);
            if (target == null)
            {
                return null;
            }

            return ToModel(target);
        }

        public Todo Find(TodoTitle title)
        {
            var target = _context.Todos
                .FirstOrDefault(todoData => todoData.Title == title.Value);
            if (target == null)
            {
                return null;
            }

            return ToModel(target);
        }

        public List<Todo> FindAll()
        {
            return _context.Todos.Select(ToModel).ToList();
        }

        public void Save(Todo todo)
        {
            var found = _context.Todos.Find(todo.Id.Value);

            if (found == null)
            {
                var data = ToDataModel(todo);
                _context.Todos.Add(data);
            }
            else
            {
                var data = Transfer(todo, found);
                _context.Todos.Update(data);
            }

            _context.SaveChanges();
        }

        private Todo ToModel(TodoDataModel from)
        {
            return new Todo(
                new TodoId(from.Id),
                new TodoTitle(from.Title),
                new TodoDeadline(from.Deadline),
                new TodoIsCompleted(from.IsCompleted)
            );
        }

        private TodoDataModel Transfer(Todo from, TodoDataModel model)
        {
            model.Id = from.Id.Value;
            model.Title = from.Title.Value;
            model.Deadline = from.Deadline.Value;
            model.IsCompleted = from.IsCompleted.Value;

            return model;
        }

        private TodoDataModel ToDataModel(Todo from)
        {
            return new TodoDataModel
            {
                Id = from.Id.Value,
                Title = from.Title.Value,
                Deadline = from.Deadline.Value,
                IsCompleted = from.IsCompleted.Value,
            };
        }
    }
}
