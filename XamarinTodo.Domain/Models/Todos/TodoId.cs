using System;

namespace XamarinTodo.Domain.Models.Todos
{
    public class TodoId : ValueObject<TodoId>
    {
        public TodoId(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            Value = value;
        }

        public string Value { get; }

        protected override bool EqualsCore(TodoId other)
        {
            return this.Value == other.Value;
        }
    }
}