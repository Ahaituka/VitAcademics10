using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicsLibrary.DataModel
{
    public class Course
    {
        public int class_number { get; set; }
        public string course_code { get; set; }
        public string course_mode { get; set; }
        public string course_option { get; set; }
        public string course_title { get; set; }
        public string subject_type { get; set; }
        public string faculty { get; set; }
        public string ltpc { get; set; }
        public string registration_status { get; set; }
        public string slot { get; set; }
        public string venue { get; set; }
        public string bill_date { get; set; }
        public string bill_number { get; set; }
        public string project_title { get; set; }
        public List<Timing> timings { get; set; }
        public Attendance attendance { get; set; }
        public Marks marks { get; set; }
    }
}
