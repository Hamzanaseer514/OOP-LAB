using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_Mclasses_.BL;
using system_Mclasses_.DL;

namespace system_Mclasses_.UI
{
   public class MUserUI
    {
        public static MUser signUp()
        {

            string pass;
            string name;
            string role = "Admin";
            Console.Write("Ënter the username Employe/Customer  : ");
            name = Console.ReadLine();
            Console.Write("Enter the passward : ");
            pass = Console.ReadLine();
            while (role != "Employe" && role != "Customer")
            {

                Console.Write("Enter the role : ");
                role = Console.ReadLine();
                if (role != "Employe" && role != "Customer")
                {
                    Console.WriteLine("You cannot signup Please try again");
                    Console.ReadKey();
                }

            }
            bool isValid = false;
            for (int i = 0; i < MUserCrud.user.Count; i++)
            {
                if (MUserCrud.user[i].username == name && MUserCrud.user[i].password == pass)
                {
                    isValid = true;
                    break;
                }
            }
            if (isValid == true)
            {
                Console.WriteLine("You cannot signup");
                Console.ReadKey();
            }
            else if (isValid == false)
            {
                MUser u = new MUser(name, pass, role);
                isValid = true;
                return u;
            }
            return null;
        }

        public static string SignIn()
        {
            
            Console.Write("Enter the user name : ");
            string name = Console.ReadLine();
            Console.Write("Enter the password : ");
            string password = Console.ReadLine();
            for (int i = 0; i < MUserCrud.user.Count; i++)
            {
                if (name == MUserCrud.user[i].username && password == MUserCrud.user[i].password)
                {
                    return MUserCrud.user[i].role;
                }
            }
            return "Undefined";
        }


        public static int menu()
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************************************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                                                       PHARMACY    MANAGEMENT    SYSTEM                                               ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("********************************************************************************************************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1.  SignUp ");
            Console.WriteLine("****************");
            Console.WriteLine("2.  SignIn ");
            Console.WriteLine("****************");
            Console.WriteLine("3.  Exist ");
            Console.WriteLine("****************");
            int option;
            Console.WriteLine("");
            Console.Write("Enter the option : ");
            Console.Write("___");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        public static int AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t ==> WELCOME TO OUR PHARMACY <== ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1. Add the Medicine");
            Console.WriteLine("2. View the Medicine");
            Console.WriteLine("3. Delete the Medicine");
            Console.WriteLine("4. Update the Quantity of medicine ");
            Console.WriteLine("5. Add the Emplyee/Admin");
            Console.WriteLine("6. View the Staff");
            Console.WriteLine("7. Remove the Employe/Admin");
            Console.WriteLine("8. Mark Attendence");
            Console.WriteLine("9. Exit");
            int option;
            Console.Write("Enter the Option : ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        public static Product Addmedicine()
        {
            string name;
            int price;
            int quantity;
            Console.Write("Enter the name ef the medicine : ");
            name = Console.ReadLine();
            Console.Write("Enter the quantity of the medicine : ");
            quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter the price of the one doze medicine : ");
            price = int.Parse(Console.ReadLine());
            Product p1 = new Product(name, quantity, price);
            return p1;
        }

        public static void removeMedicine()
        {
            string name;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t====>  AVAILABLE   STOCK   OF  MEDICINE <===");
            for (int i = 0; i < MUserCrud.prdct.Count; i++)
            {

                Console.WriteLine("");
                Console.Write("\t\t\t" + "  Medicine " + " : ");
                Console.WriteLine(MUserCrud.prdct[i].medicineName);
                Console.Write("\t\t\t" + "  Quantity " + " : ");
                Console.WriteLine(MUserCrud.prdct[i].medicineQuantity);
                Console.Write("\t\t\t" + "  Price " + " : ");
                Console.WriteLine(MUserCrud.prdct[i].medicinePrice);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t ===> Press any key to Remove the medicine <===");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Enter the name of medicine you want to remove : ");
            name = Console.ReadLine();
            MUserCrud.RemoveMedicinefromlist(name);
            Console.WriteLine("\t\t\t\tRemoved Successfully");
            Console.ReadKey();        // otherwise use remove if object is passed.....
        }

        public static MUser AddEmploye()
        {
            string pass;
            string name;
            string role = "Admin";
            Console.Write("Ënter the username Employe/Customer  : ");
            name = Console.ReadLine();
            Console.Write("Enter the passward : ");
            pass = Console.ReadLine();
            while (role != "Employe" && role != "Customer")
            {

                Console.Write("Enter the role : ");
                role = Console.ReadLine();
                if (role != "Employe" && role != "Customer")
                {
                    Console.WriteLine("You cannot signup Please try again");
                    Console.ReadKey();
                    continue;
                }
                MUser u = new MUser(name, pass, role);
                return u;

            }
            return null;
        }

        public static void RemoveStaff()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t ===> Press any key to Remove the Staff <===");
            Console.ReadKey();
            Console.Clear();
            string name;
            string password;
            Console.Write("Enter the name of the employe you want to remove :  ");
            name = Console.ReadLine();
            Console.Write("Enter the Password of the employe :  ");
            password = Console.ReadLine();
            bool flag = MUserCrud.removeStaffFromList(name, password);
            if (flag == false)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("\t\t\t\tUser not found try again ");
                Console.ReadKey();

            }
            if (flag == true)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("\t\t\t\tRemoved Successfully");
                Console.ReadKey();
            }
        }
    }
}
