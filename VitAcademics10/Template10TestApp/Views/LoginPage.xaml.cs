using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
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
        private static string refresh;
        private static string _regNo;

        public string Registration { get; set; }

        public LoginPage()
        {
            this.InitializeComponent();
            this.DataContext = this;

        }



        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            RootGrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            LoadingGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
            login = await DataManager.LoginAsync(campus, Registration, Password.Password);
            if (login)
            {
                Refresh_Button_Click(sender, e);
            }
            else
            {
                MessageDialog.ShowDialog(DataManager.user.status.message);
                LoadingGrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                RootGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
                

            }
            //Frame.Navigate(typeof(MainPage));
        }

        private  void Radio_Vellore_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            campus = rb.Content.ToString().ToLower();

        }

        private async void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            
            var refresh = await DataManager.RefreshAsync(campus, Registration, Password.Password);
            if (login)
            {
                Shell.HamburgerMenu.IsFullScreen = false;
                var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
                nav.Navigate(typeof(Views.MainPage));
                //MessageDialog.ShowDialog("Login Successful");
            }
            else
            {
                MessageDialog.ShowDialog(DataManager.user.status.message);
                LoadingGrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                RootGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }

        }
    }
}
