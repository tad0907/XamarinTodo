using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTodo.Domain.Models.Todos;
using XamarinTodo.SQLite.Contexts;
using XamarinTodo.SQLite.Persistence.Todos;
using XamarinTodo.UseCase.UseCases.Todos;

namespace XamarinTodoNotPrism
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<LocalDbContext>();
            optionsBuilder.UseSqlite(@"Data Source=" + Path.Combine(FileSystem.AppDataDirectory, "local.db3"));
            DependencyService.RegisterSingleton(new LocalDbContext(optionsBuilder.Options));

            DependencyService.Register<TodoUseCase>();
            DependencyService.Register<ITodoRepository, TodoRepository>();
            DependencyService.Register<ITodoFactory, TodoFactory>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
