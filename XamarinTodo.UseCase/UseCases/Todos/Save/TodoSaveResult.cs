using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.UseCase.UseCases.Todos.Save
{
    public class TodoSaveResult
    {
        public TodoSaveResult(Guid createdId)
        {
            CreatedId = createdId;
        }

        public Guid CreatedId { get; private set; }
    }
}
