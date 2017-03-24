using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AcademicsLibrary.NetworkService;
using AcademicsLibrary.DataModel;
using AcademicsLibrary.Managers;
using Template10.Services.NavigationService;
using Template10.Common;
using AcademicsLibrary.Helpers;

namespace Template10TestApp.Views
{
    public sealed partial class MainPage : Page
    {
        public List<Course> Course { get; set; }

        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            //pageTitle.Text = "Hello " + DataManager.Refresh.name;
            Course = DataManager.Refresh.courses;
        }
    }
}
