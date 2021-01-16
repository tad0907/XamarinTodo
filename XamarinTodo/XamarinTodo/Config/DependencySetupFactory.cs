using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.Config
{
    class DependencySetupFactory
    {
        public IDependencySetup CreateSetup(IConfiguration configuration)
        {
            var setupName = configuration["Dependency:setup"];
            switch (setupName)
            {
                case nameof(DependencySetup):
                    return new DependencySetup(configuration);

                default:
                    throw new NotSupportedException(setupName + " is not registered.");
            }
        }
    }
}
