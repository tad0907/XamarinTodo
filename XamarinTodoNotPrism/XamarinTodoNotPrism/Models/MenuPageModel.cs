using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodoNotPrism.Models
{
    public class MenuPageModel
    {
        public MenuPageModel(string title, string pageName, string imageName, string textColor)
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
