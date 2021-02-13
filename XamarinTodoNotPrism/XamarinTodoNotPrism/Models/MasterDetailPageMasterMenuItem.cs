using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinTodoNotPrism.Models
{
    public class MasterDetailPageMasterMenuItem
    {
        public MasterDetailPageMasterMenuItem(
            int id,
            string title,
            string pageName,
            string imageName,
            string textColor)
        {
            Id = id;
            Title = title;
            PageName = pageName;
            ImageName = imageName;
            TextColor = textColor;
        }
        public int Id { get; }
        public string Title { get; private set; }
        public string PageName { get; private set; }
        public string ImageName { get; private set; }
        public string TextColor { get; private set; }
    }
}