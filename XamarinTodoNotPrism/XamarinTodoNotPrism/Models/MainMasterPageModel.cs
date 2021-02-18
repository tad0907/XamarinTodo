using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XamarinTodoNotPrism.Models
{
    public class MainMasterPageModel
    {
        public ObservableCollection<MasterDetailPageMasterViewModel> MenuItems { get; }
            = new ObservableCollection<MasterDetailPageMasterViewModel>();
    }
}
