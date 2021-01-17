using System;
using XamarinTodo.Domain.Models.Common;

namespace XamarinTodo.Domain.Models.Todos
{
    public class TodoId : ValueObject<TodoId>
    {
        public TodoId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        protected override bool EqualsCore(TodoId other)
        {
            return this.Value == other.Value;
        }
    }
}