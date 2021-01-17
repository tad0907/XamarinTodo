using System;
using XamarinTodo.Domain.Exceptions;
using XamarinTodo.Domain.Models.Common;

namespace XamarinTodo.Domain.Models.Todos
{
    public class TodoTitle : ValueObject<TodoTitle>
    {
        private readonly string _name = "タイトル";

        private readonly int _maxLength = 20;

        public TodoTitle(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullOrEmptyException(_name);

            if (value.Length > _maxLength)
                throw new ArgumentOverLengthException(_name, _maxLength);

            Value = value;
        }

        public string Value { get; }

        protected override bool EqualsCore(TodoTitle other)
        {
            return this.Value == other.Value;
        }
    }
}