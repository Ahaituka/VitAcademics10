using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicsLibrary.DataModel
{
    public class User
    {

        //public string RegNo{get;private set;}
        //public string Pass   { get; private set; }
        //public string Campus { get; private set; }

        //public string message { get; set; }
        //public int code { get; set; }      

        public class Status
        {
            public string message { get; set; }
            public int code { get; set; }
        }

      
            public string RegNo { get; set; }
            public string Campus { get; set; }
            public Status status = new Status();
            public string Pass { get; set; }


        public User(string campus, string reg, string pass,int code=5,string message = null )
        {
            Campus = campus;
            RegNo = reg;
            Pass = pass;
            status.code = code;
            status.message = message;
        }

        public User()
        {

        }


    }
}
