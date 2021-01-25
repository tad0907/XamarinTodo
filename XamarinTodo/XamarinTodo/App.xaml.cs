using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using XamarinTodo.Domain.Models.Todos;
using XamarinTodo.InMemory.Persistence.Todos;
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
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterSingleton<ITodoFactory, InMemoryTodoFactory>();
            containerRegistry.RegisterSingleton<ITodoRepository, InMemoryTodoRepository>();

            containerRegistry.RegisterScoped<TodoUseCase>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<TodoListPage, TodoListPageViewModel>();

            containerRegistry.RegisterForNavigation<TodoEditPage, TodoEditPageViewModel>();
            containerRegistry.RegisterForNavigation<TodoCreatePage, TodoCreatePageViewModel>();
        }
    }
}
