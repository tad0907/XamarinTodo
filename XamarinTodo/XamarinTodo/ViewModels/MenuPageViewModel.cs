using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinTodo.ViewModels
{
    public class MenuPageViewModel : BindableBase
    {
        public MenuPageViewModel(string title, string pageName, string imageName, string textColor)
        {
            Title = title;
            PageName = pageName;
            ImageName = imageName;
            TextColor = textColor;
        }
        public string Title { get; }
        public string PageName { get; }
        public string ImageName { get; }
        public string TextColor { get; }
    }
}
