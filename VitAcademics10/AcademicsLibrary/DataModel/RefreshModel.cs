using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicsLibrary.DataModel
{
    public class RefreshModel
    {
        
        public class GradeSummary
        {
            public string __invalid_name__Agrades { get; set; }

        }


        public class SubHistory
        {
            public string course_title { get; set; }
            public string course_type { get; set; }
            public int credit { get; set; }
            public string grade { get; set; }
        }

        public class History1
        {
            public SubHistory SubHistory { get; set; }
        }

        public class History2
        {
            public double cgpa { get; set; }
            public int __invalid_name__creditsearned { get; set; }
            public int __invalid_name__creditsregistered { get; set; }
            public string rank { get; set; }
        }

        public class AcademicHistory
        {
            public GradeSummary __invalid_name__gradesummary { get; set; }
            public History1 __invalid_name__history1 { get; set; }
            public History2 __invalid_name__history2 { get; set; }
            public string status { get; set; }
        }

        public class FacultyDet
        {
            public string Designation { get; set; }
            public string __invalid_name__EmailId { get; set; }
            public string __invalid_name__IntercomNo { get; set; }
            public string __invalid_name__MobileNoPhoneNo { get; set; }
            public string Name { get; set; }
            public string __invalid_name__RoomNo { get; set; }
            public string School { get; set; }
            public string photo { get; set; }
        }

        public class FacultyAdvisor
        {
            public string status { get; set; }
            public FacultyDet faculty_det { get; set; }
        }



        public class Cat1
        {
            public Cat1course excourse { get; set; }
        }



        public class Cat1course
        {
            public string crTitle { get; set; }
            public string slot { get; set; }
            public string date { get; set; }
            public string day { get; set; }
            public string session { get; set; }
            public string time { get; set; }
        }

        public class Cat2course
        {
            public string crTitle { get; set; }
            public string slot { get; set; }
            public string date { get; set; }
            public string day { get; set; }
            public string session { get; set; }
            public string time { get; set; }
        }

        public class Cat2
        {
            public Cat2course excourse { get; set; }
        }

        public class ExamSchedule
        {
            public string status { get; set; }
            public Cat1 cat1 { get; set; }
            public Cat2 cat2 { get; set; }
            public object termend { get; set; }
        }

        public class Status
        {
            public string message { get; set; }
            public int code { get; set; }
        }

       
            public string reg_no { get; set; }
            public string name { get; set; }
            public string school { get; set; }
            public string campus { get; set; }
            public string semester { get; set; }
            public List<Course> courses { get; set; }
            public AcademicHistory academic_history { get; set; }
            public FacultyAdvisor faculty_advisor { get; set; }
            public ExamSchedule exam_schedule { get; set; }
            public Status status { get; set; }
        

    }
}
