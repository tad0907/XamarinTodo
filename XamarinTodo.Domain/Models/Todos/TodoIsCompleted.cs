namespace XamarinTodo.Domain.Models.Todos
{
    public class TodoIsCompleted : ValueObject<TodoIsCompleted>
    {
        public TodoIsCompleted(bool value)
        {
            Value = value;
        }

        public bool Value { get; }

        protected override bool EqualsCore(TodoIsCompleted other)
        {
            return this.Value == other.Value;
        }
    }
}