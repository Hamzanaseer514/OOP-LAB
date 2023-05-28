using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_Mclasses_.BL
{
    public class MUser
    {
        public string username;
        public string password;
        public string role;

        public MUser(string name, string password, string role)
        {
            this.username = name;
            this.password = password;
            this.role = role;
        }

        public MUser(string name, string password)
        {
            this.username = name;
            this.password = password;
        }
    }
}
