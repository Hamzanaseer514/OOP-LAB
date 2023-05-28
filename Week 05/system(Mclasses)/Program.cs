using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_Mclasses_.BL;
using system_Mclasses_.DL;
using system_Mclasses_.UI;

namespace system_Mclasses_
{ss
    class Program
    {
        static void Main(string[] args)
        {
            string a_name;
            string a_pass;
            string a_role;
            a_name = "hamza123";
            a_pass = "abcd";
            a_role = "Admin";
            MUser u = new MUser(a_name, a_pass, a_role);
            MUserCrud.AddUserIntoList(u);
            int option = 0;
            while (option != 8)
            {
                option = MUserUI.menu();
                if (option == 1)
                {
                    MUser u1 = MUserUI.signUp();
                    MUserCrud.AddUserIntoList(u1);
                }
                if (option == 2)
                {
                    string role = MUserUI.SignIn();
                    if (role == "Admin")
                    {
                        int choice;
                        while (true)
                        {

                            choice = MUserUI.AdminMenu();
                            if (choice == 1)
                            {
                                Product p = MUserUI.Addmedicine();
                                MUserCrud.AddProductIntoList(p);
                            }
                            if (choice == 2)
                            {
                                MUserCrud.viewMedicine();
                            }
                            if(choice == 3)
                            {
                                MUserUI.removeMedicine();
                            }
                            if(choice == 5)
                            {
                                MUser u2 = MUserUI.AddEmploye();
                                MUserCrud.user.Add(u2);
                            }
                            if(choice == 6)
                            {
                                MUserCrud.viewStaff();
                            }
                            if(choice == 7)
                            {
                                MUserUI.RemoveStaff();
                            }
                        }
                    }
                    else if (role == "Employe")
                    {
                        Console.WriteLine("Employe Interface ");
                        Console.ReadKey();
                    }
                    else if (role == "Customer")
                    {
                        Console.WriteLine("Customer Interface ");
                        Console.ReadKey();
                    }
                }
                if (option == 3)
                {
                    break;
                }
            }


        }
    }
}
