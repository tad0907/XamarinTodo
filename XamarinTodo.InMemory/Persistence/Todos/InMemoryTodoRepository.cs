using System;
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

        public List<Todo> FindAll()
        {
            return CreateFake();

            /*
            return Db.Values
                .Select(DeepClone)
                .ToList();
            */
        }

        private List<Todo> CreateFake()
        {
            var todos = new List<Todo>();
            for(var i = 0; i < 3; i++)
            {
                var id = new TodoId(Guid.NewGuid());
                var title = new TodoTitle((i + 1).ToString() + "番目のタイトル");
                var deadline = new TodoDeadline(new DateTime(2021, 1, i + 1));
                var isCompleted = new TodoIsCompleted(false);
                todos.Add(new Todo(id, title, deadline, isCompleted));
            }

            return todos;
        }
    }
}
