using System;
using System.Configuration;
using System.Data;
using System.Windows;
using Recipe.Models;

namespace Recipe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Person? CurrentUser = null;
    }

}
