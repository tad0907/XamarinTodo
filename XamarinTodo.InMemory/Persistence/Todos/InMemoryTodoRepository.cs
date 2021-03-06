﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinTodo.Domain.Models.Todos;
using XamarinTodo.InMemory.Foundation;

namespace XamarinTodo.InMemory.Persistence.Todos
{
    public class InMemoryTodoRepository : InMemoryRepositoryBase<TodoId, Todo>, ITodoRepository
    {
        protected override TodoId GetKey(Todo value)
        {
            return value.Id;
        }

        protected override Todo DeepClone(Todo value)
        {
            return new Todo(
                value.Id,
                value.Title,
                value.Deadline,
                value.IsCompleted
            );
        }

        public Todo Find(TodoTitle title)
        {
            var target = Db.Values.FirstOrDefault(x => x.Title.Equals(title));
            if (target != null)
            {
                return DeepClone(target);
            }
            else
            {
                return null;
            }
        }

        public List<Todo> List(Func<Todo, bool> condition)
        {
            return Db.Values
                .Select(DeepClone)
                .Where(condition)
                .ToList();
        }

        public List<Todo> List()
        {
            return Db.Values
                .Select(DeepClone)
                .ToList();
        }
    }
}
