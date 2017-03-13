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
using AcademicsLibrary.Helpers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private async void Login_Click(object sender, RoutedEventArgs e)
        {

            campus.Text = "vellore";
            reg.Text = "14bce0725";
            pass.Text = "Shubham@990";
            MessageDialog.ShowDialog(await NetworkService.Login(campus.Text, reg.Text, pass.Text));

        }

        private async void Refersh_CLick(object sender, RoutedEventArgs e)
        {
            MessageDialog.ShowDialog(await NetworkService.Refresh(campus.Text, reg.Text, pass.Text));
        }
    }
}
