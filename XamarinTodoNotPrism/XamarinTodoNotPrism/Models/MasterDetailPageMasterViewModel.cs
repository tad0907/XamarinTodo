using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinTodoNotPrism.Models
{
    public class MasterDetailPageMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MasterDetailPageMasterMenuItem> MenuItems { get; set; }
            = new ObservableCollection<MasterDetailPageMasterMenuItem>();

        public MasterDetailPageMasterViewModel()
        {
            MenuItems.Add(new MasterDetailPageMasterMenuItem(0, "Today", "TodoListPage", "Sun", "LightPink"));
            MenuItems.Add(new MasterDetailPageMasterMenuItem(1, "Importance", "TodoListPage", "MtFuji", "Red"));
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
