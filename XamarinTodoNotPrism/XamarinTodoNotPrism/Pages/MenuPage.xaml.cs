﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTodoNotPrism.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentView
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}