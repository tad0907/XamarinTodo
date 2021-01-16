using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.Config
{
    public interface IDependencySetup
    {
        void Run(IServiceCollection services);
    }
}
