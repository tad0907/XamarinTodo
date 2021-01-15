using System;

namespace XamarinTodo.Domain.Models.Todos
{
    public class TodoDeadline : ValueObject<TodoDeadline>
    {
        public TodoDeadline(DateTime? value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Value = value;
        }

        public DateTime? Value { get; }

        protected override bool EqualsCore(TodoDeadline other)
        {
            return this.Value == other.Value;
        }
    }
}