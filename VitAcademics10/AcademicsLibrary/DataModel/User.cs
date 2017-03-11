using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicsLibrary.DataModel
{
    public class User
    {
        
        public string RegNo{get;private set;}
        public string Pass   { get; private set; }
        public string Campus { get; private set; }

        public User(string campus, string reg, string pass)
        {
            Campus = campus;
            RegNo = reg;
            Pass = pass;

        }
   

    }
}
