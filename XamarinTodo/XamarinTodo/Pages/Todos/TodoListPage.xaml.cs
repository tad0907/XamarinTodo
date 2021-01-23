using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTodo.Domain.Models.Todos;
using XamarinTodo.Domain.Services;
using XamarinTodo.SQLite.Contexts;
using XamarinTodo.SQLite.Persistence.Todos;
using XamarinTodo.UseCase.UseCases.Todos;

namespace XamarinTodo.Pages.Todos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListPage : ContentPage
    {
        private TodoUseCase _todoUseCase;

        public TodoListPage(TodoUseCase todoUseCase)
        {
            InitializeComponent();

            _todoUseCase = todoUseCase;

            var result = _todoUseCase.GetAll();

            TodoListView.ItemsSource = result.Todos;
        }

        private void TodoListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}