using System;
using XamarinTodo.Domain.Models.Common;

namespace XamarinTodo.Domain.Models.Todos
{
    public class TodoId : ValueObject<TodoId>
    {
        public TodoId(string value)
        {
            Value = value;
        }

        public string Value { get; }

        protected override bool EqualsCore(TodoId other)
        {
            return this.Value == other.Value;
        }
    }
}