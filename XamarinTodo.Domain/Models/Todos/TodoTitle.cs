using System;
using XamarinTodo.Domain.Models.Common;

namespace XamarinTodo.Domain.Models.Todos
{
    public class TodoTitle : ValueObject<TodoTitle>
    {
        public TodoTitle(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            Value = value;
        }

        public string Value { get; }

        protected override bool EqualsCore(TodoTitle other)
        {
            return this.Value == other.Value;
        }
    }
}