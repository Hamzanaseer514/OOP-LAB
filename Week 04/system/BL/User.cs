using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system.BL
{
    class User
    {
        public User(string name, string pass, string role)
        {
            this.username = name;
            this.password = pass;
            this.roles = role;
        }
        public User(string name, string attendence)
        {
            this.username = name;
            this.attendence = attendence;
        }

        public void ViewStaff()
        {

            Console.Write("\t\t\tUser Name " + " :  \t\t");
            Console.WriteLine(this.username);
            Console.WriteLine("");
            Console.Write("\t\t\tPassward " + " : \t\t");
            Console.WriteLine(this.password);
            Console.WriteLine("");
            Console.Write("\t\t\tRole " + " : \t\t");
            Console.WriteLine(this.roles);
            Console.ReadKey();

        }

        public string username;
        public string password;
        public string roles;
        public string attendence;
    }
}
