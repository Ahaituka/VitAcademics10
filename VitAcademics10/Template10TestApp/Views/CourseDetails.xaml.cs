using AcademicsLibrary.DataModel;
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
using AcademicsLibrary.Managers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Template10TestApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CourseDetails : Page
    {
        public Course Course { get; set; }
        public Course recieved { get; set; }
        public List<Detail> attendanceDetails {get; set;}
        public CourseDetails()
        {
            this.InitializeComponent();
            //Course_Name.Text = Course.course_title;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            recieved = DataManager.navData;
            attendanceDetails = recieved.attendance.details;

        }
    }
}
