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
using Windows.Storage;
using Windows.UI.ViewManagement;
using Microsoft.Toolkit.Uwp.UI;

namespace Template10TestApp.Views
{
    public sealed partial class MainPage : Page
    {
        public User Details { get; set; }
        public List<Course> Course { get; set; }
        public Course selected { get; set; }
        public AdvancedCollectionView acv { get; set; }

        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            //pageTitle.Text = "Hello " + DataManager.Refresh.name;
            Details = DataManager.user;
            Course = DataManager.Refresh.courses;
            greetbox.Text = DataManager.Refresh.name.ToString();
            var time = DateTime.Now;

            acv = new AdvancedCollectionView(Course);
            acv.SortDescriptions.Add(new SortDescription("course_title", SortDirection.Ascending));

            if (time.Hour > 19 || time.Hour < 5)
            {
                RootGrid.Background = (SolidColorBrush)Resources["NightColor"];
                MyHead.Background = (SolidColorBrush)Resources["NightColor"];
                var k = welcomeImage.Background;
                welcomeImage.Background = (ImageBrush)Resources["NightImage"];
            }

            if (ApplicationView.GetForCurrentView().IsViewModeSupported(ApplicationViewMode.CompactOverlay))
            {
                overlay.Visibility = Visibility.Visible;
            }

        }



        private void Course_ItemClick(object sender, ItemClickEventArgs e)
        {
            //detailPresenter.Content = CourseDetails;
            selected = (Course)e.ClickedItem;
            DataManager.navData = selected;
            this.Frame.Navigate(typeof(CourseDetails));
        }

        private async void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            string campus = localSettings.Values["campus"].ToString();
            string reg = localSettings.Values["user"].ToString();
            string pass = (string)localSettings.Values["pass"];
            LoadingGrid.Visibility = Visibility.Visible;
            RootGrid.Visibility = Visibility.Collapsed;
            var refresh = await DataManager.RefreshDataAsync(campus, reg, pass);
            
            if (refresh == DataManager.StatusCode.Success)
            {
                Course = DataManager.Refresh.courses;
                LoadingGrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                RootGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                MessageDialog.ShowDialog(DataManager.user.status.message);
                LoadingGrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                RootGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }

        private void courseTile_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Courses));
        }

        private async void overlay_Click(object sender, RoutedEventArgs e)
        {
            bool modeSwitched = await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.CompactOverlay);

        }

        private async void NormalMode_Click(object sender, RoutedEventArgs e)
        {
            bool modeSwitched = await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.Default);
        }
    }
}
