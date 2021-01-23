using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.Config
{
    class DependencySetupFactory
    {
        public IDependencySetup CreateSetup()
        {
            return new DependencySetup();
        }
    }
}
