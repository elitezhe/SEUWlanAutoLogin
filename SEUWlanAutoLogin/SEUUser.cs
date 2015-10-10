using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEUWlanAutoLogin
{
    class SEUUser
    {
        public string StuID { get; set; }
        public string Pwd { get; set; }

        public SEUUser() { }
        public SEUUser(string stuId, string Pwd)
        {
            this.StuID = stuId;
            this.Pwd = Pwd;
        }
        public SEUUser(SEUUser aSeuUser)
        {
            this.StuID = aSeuUser.StuID;
            this.Pwd = aSeuUser.Pwd;
        }
    }
}
