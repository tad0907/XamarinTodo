using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.InMemory.Foundation
{
    public class SerialNumberAssigner
    {
        private int currentId;

        public int Next()
        {
            return ++currentId;
        }

        public void ChangeCurrent(int id)
        {
            currentId = id;
        }
    }
}
