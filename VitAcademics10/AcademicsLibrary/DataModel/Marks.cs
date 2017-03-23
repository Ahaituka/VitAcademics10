using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicsLibrary.DataModel
{
    public class Assessment
    {
        public string title { get; set; }
        public int max_marks { get; set; }
        public int weightage { get; set; }
        public string conducted_on { get; set; }
        public string status { get; set; }
        public int scored_marks { get; set; }
        public double scored_percentage { get; set; }
    }

    public class Marks
    {
        public List<Assessment> assessments { get; set; }
        public int max_marks { get; set; }
        public int max_percentage { get; set; }
        public int scored_marks { get; set; }
        public double scored_percentage { get; set; }
    }
}
