using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prism;
using Prism.Ioc;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using XamarinTodo.Domain.Models.Todos;
using XamarinTodo.InMemory.Persistence.Todos;
using XamarinTodo.SQLite.Contexts;
using XamarinTodo.SQLite.Persistence.Todos;
using XamarinTodo.UseCase.UseCases.Todos;
using XamarinTodo.ViewModels;
using XamarinTodo.Views;

namespace XamarinTodo
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/TodoListPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LocalDbContext>();
            optionsBuilder.UseSqlite(@"Data Source=" + Path.Combine(FileSystem.AppDataDirectory, "local.db3"));
            containerRegistry.RegisterInstance(optionsBuilder.Options);
            containerRegistry.RegisterSingleton<LocalDbContext>();

            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterSingleton<ITodoFactory, TodoFactory>();
            containerRegistry.RegisterSingleton<ITodoRepository, TodoRepository>();

            containerRegistry.RegisterSingleton<TodoUseCase>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<TodoListPage, TodoListPageViewModel>();

            containerRegistry.RegisterForNavigation<TodoEditPage, TodoEditPageViewModel>();
            containerRegistry.RegisterForNavigation<TodoCreatePage, TodoCreatePageViewModel>();
        }
    }
}
