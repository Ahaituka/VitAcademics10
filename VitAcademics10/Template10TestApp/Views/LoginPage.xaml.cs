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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Template10TestApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private static string campus;
        private static bool login;

        public LoginPage()
        {
            this.InitializeComponent();
          
        }



        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var x = 5;
            login = await DataManager.LoginAsync(campus, RegNo.Text, Password.Password);
            if (login)
            {
                Shell.HamburgerMenu.IsFullScreen = false;
                var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
                nav.Navigate(typeof(Views.MainPage));
            }
            else
            {
                MessageDialog.ShowDialog(DataManager.user.status.message);

            }
            //Frame.Navigate(typeof(MainPage));
        }

        private  void Radio_Vellore_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            campus = rb.Content.ToString().ToLower();

        }

       
    }
}
