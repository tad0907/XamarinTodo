using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.Domain.Exceptions
{
    public class ArgumentNullOrEmptyException : Exception
    {
        public ArgumentNullOrEmptyException()
        {
        }

        public ArgumentNullOrEmptyException(string paramName)
            : base(paramName + "を入力してください。")
        {
        }
    }
}
