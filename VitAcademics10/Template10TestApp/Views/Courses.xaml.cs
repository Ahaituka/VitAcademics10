using AcademicsLibrary.DataModel;
using AcademicsLibrary.Managers;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Template10TestApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Courses : Page
    {
        public List<Course> Course { get; set; }
        public Course selected { get; set; }
        public Courses()
        {
            this.InitializeComponent();
            Course = DataManager.Refresh.courses;
        }

        private void Course_ItemClick(object sender, ItemClickEventArgs e)
        {
            //detailPresenter.Content = CourseDetails;
            selected = (Course)e.ClickedItem;
            DataManager.navData = selected;
            this.Frame.Navigate(typeof(CourseDetails));
        }
    }
}
