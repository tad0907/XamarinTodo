using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.Domain.Exceptions
{
    public class ArgumentOverLengthException : Exception
    {
        public ArgumentOverLengthException()
        {
        }

        public ArgumentOverLengthException(string paramName, int max)
            : base(paramName + "を" + max.ToString() + "文字以内で入力してください。")
        {
        }
    }
}
