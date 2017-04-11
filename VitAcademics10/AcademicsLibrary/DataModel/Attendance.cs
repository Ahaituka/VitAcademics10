using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicsLibrary.DataModel
{
    public class Detail
    {
        public int sl { get; set; }
        public int class_units { get; set; }
        public string date { get; set; }
        public string reason { get; set; }
        public string slot { get; set; }
        public string status { get; set; }
    }

    public class Attendance
    {
        public int attendance_percentage { get; set; }
        public int attended_classes { get; set; }
        public List<Detail> details { get; set; }
        public string registration_date { get; set; }
        public int total_classes { get; set; }
    }
}
