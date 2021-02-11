using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XamarinTodoNotPrism.Models
{
    public class MainMaseterPageModel
    {
        public ObservableCollection<MenuPageModel> MenuItems { get; }
            = new ObservableCollection<MenuPageModel>
        {
            new MenuPageModel("Today", "TodoListPage", "Sun", "LightPink"),
            new MenuPageModel("Importance", "TodoListPage", "MtFuji", "Red")
        };
    }
}
