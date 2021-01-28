using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinTodo.ViewModels
{
    public class MainMasterPageViewModelMenu
    {
        public MainMasterPageViewModelMenu(string title, string pageName)
        {
            Title = title;
            PageName = pageName;
        }

        public string Title { get; set; }

        public string PageName { get; set; }
    }
}
