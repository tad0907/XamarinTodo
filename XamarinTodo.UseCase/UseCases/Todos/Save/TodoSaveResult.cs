using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.UseCase.UseCases.Todos.Save
{
    public class TodoSaveResult
    {
        public TodoSaveResult(string createdId)
        {
            CreatedId = createdId;
        }

        public string CreatedId { get; private set; }
    }
}
