using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamarinTodo.Models.Common
{
    /// <summary>
    /// ViewModelの基本クラス
    /// </summary>
    public class PageModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// プロパティの変更があった時に発行される
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChangedイベントを発行する
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
