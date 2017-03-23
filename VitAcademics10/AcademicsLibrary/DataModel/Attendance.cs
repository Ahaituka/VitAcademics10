using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicsLibrary.DataModel
{
    public class Attendance
    {
        public int attendance_percentage { get; set; }
        public int attended_classes { get; set; }
        public List<Detail> details { get; set; }
        public string registration_date { get; set; }
        public int total_classes { get; set; }
    }
}
