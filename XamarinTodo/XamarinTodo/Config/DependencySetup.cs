using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinTodo.Domain.Models.Todos;
using XamarinTodo.SQLite.Contexts;
using XamarinTodo.SQLite.Persistence.Todos;
using XamarinTodo.UseCase.UseCases.Todos;

namespace XamarinTodo.Config
{
    public class DependencySetup : IDependencySetup
    {
        public DependencySetup()
        {
        }

        public void Run(IServiceCollection services)
        {
            SetupFactories(services);
            SetupRepositories(services);
            SetupQueryServices(services);
            SetupApplicationServices(services);
            SetupDomainServices(services);
        }

        private void SetupFactories(IServiceCollection services)
        {
            services.AddTransient<ITodoFactory, TodoFactory>();
        }

        private void SetupRepositories(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlite("");
            });

            services.AddTransient<ITodoRepository, TodoRepository>();
        }

        private void SetupQueryServices(IServiceCollection services)
        {
        }

        private void SetupApplicationServices(IServiceCollection services)
        {
            services.AddTransient<TodoUseCase>();
        }

        private void SetupDomainServices(IServiceCollection services)
        {
        }
    }
}
