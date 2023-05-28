using system.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_constructor_
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrSize = 20;

            //List<datatype> = new List<dataType>();

            List<User> u = new List<User>();
            List<Products> prdct = new List<Products>();
            string a_name;
            string a_pass;
            string a_role;
            //     int userCount = 1;
            // u[0] = new User();
            a_name = "hamza123";
            a_pass = "abcd";
            a_role = "Admin";
            User a = new User(a_name, a_pass, a_role);
            u.Add(a);                               // data add to list u 
            LoadData(u);
            LoadMedicine(prdct);
            LoadAttendence(u);
            int option = 0; ;
            while (option != 4)
            {
                option = menu();
                if (option == 1)
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
                    bool isValid = SignUp(u, name, pass, role, arrSize);
                    if (isValid)
                    {
                        Console.WriteLine("Sign up Successfully");
                        Console.ReadKey();
                    }
                    if (!(isValid))
                    {
                        Console.WriteLine("User already present");
                        Console.ReadKey();
                    }
                }
                if (option == 2)
                {
                    string pass;
                    string name;
                    string role;
                    Console.Write("Ënter the username Employe/Customer  : ");
                    name = Console.ReadLine();
                    Console.Write("Enter the passward : ");
                    pass = Console.ReadLine();
                    role = SignIn(u, name, pass);
                    if (role == "Admin")
                    {
                        AdminInterface(prdct, u);
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
            }
        }

        static int menu()
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

        static bool SignUp(List<User> u, string name, string pass, string role, int arrSize)
        {

            bool isValid = false;
            for (int i = 0; i < u.Count; i++)
            {
                if (u[i].username == name && u[i].password == pass)
                {
                    isValid = true;
                }
            }
            if (isValid == true)
            {
                return false;
            }
            if (u.Count < arrSize)
            {
                User a = new User(name, pass, role);
                u.Add(a);
                StoreData(u);
                isValid = true;
                return isValid;
            }
            else
            {
                return isValid;
            }
        }

        static string SignIn(List<User> u, string name, string pass)
        {
            for (int i = 0; i < u.Count; i++)
            {
                if (u[i].username == name && u[i].password == pass)
                {
                    return u[i].roles;
                }
            }
            return "Undefined";
        }
        static void StoreData(List<User> u)
        {
            StreamWriter file = new StreamWriter("D:\\2nd semester OOP\\OOP PD\\Week 04\\system\\Data.txt");
            for (int i = 1; i < u.Count; i++)
            {
                file.Write(u[i].username + ",");
                file.Write(u[i].password + ",");
                file.WriteLine(u[i].roles);
            }
            file.Close();

        }

        static void LoadData(List<User> u)
        {
            string pass;
            string name;
            string role;
            string path = "D:\\2nd semester OOP\\OOP PD\\Week 04\\system\\Data.txt";
            StreamReader file = new StreamReader(path);
            if (File.Exists(path))
            {
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    name = parseData(record, 1);
                    pass = parseData(record, 2);
                    role = parseData(record, 3);
                    User a = new User(name, pass, role);
                    u.Add(a);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File doesnot Exists");
            }

        }

        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        static int AdminMenu()
        {
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

        static void displayMenu()
        {
            Console.WriteLine("*********************************************************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                      PHARMACY    MANAGEMENT    SYSTEM                                               ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("*********************************************************************************************************************");
        }

        static void AdminInterface(List<Products> prdct, List<User> u)
        {
            bool exists = false;
            while (exists == false)
            {
                Console.Clear();
                displayMenu();
                int option = AdminMenu();
                {
                    if (option == 1)
                    {
                        prdct.Add(AddMedicine());
                        StoreMedicine(prdct);
                    }
                    if (option == 2)
                    {
                        for (int i = 0; i < prdct.Count; i++)
                        {
                            Console.Clear();
                            displayMenu();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            prdct[i].ViewMedicine();
                        }

                    }
                    if (option == 3)
                    {
                        RemoveMedicine(prdct);

                    }

                    if (option == 4)
                    {
                        UpdateMedicine(prdct);

                    }
                    if (option == 5)
                    {
                        u.Add(AddStaff());
                        StoreData(u);
                    }
                    if (option == 7)
                    {
                        RemoveStaff(u);
                    }
                    if (option == 6)
                    {
                        for (int i = 0; i < u.Count; i++)
                        {
                            Console.Clear();
                            displayMenu();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            u[i].ViewStaff();
                        }
                    }
                    if (option == 8)
                    {
                        markAttendence(u);
                    }
                    if (option == 9)
                    {
                        exists = true;
                    }
                    if (option > 9 || option < 1)
                    {
                        Console.WriteLine("\t\t\t\t ===> Please Enter the Correct option <===");
                        Console.ReadKey();
                        continue;
                    }
                }

            }

        }

        static Products AddMedicine()
        {
            string medName;
            int medQuantity;
            string valid2;
            Console.Write("Enter  the name of medicine : ");
            medName = Console.ReadLine();

            Console.Write("Enter  the Quantity of medicine : ");
            valid2 = (Console.ReadLine());
            while (!(intChecking(valid2)))
            {
                Console.WriteLine("INVALID RESPONSE TRY AGAIN");
                Console.Write("Enter the quantity of Medicine : ");
                valid2 = (Console.ReadLine());
            }

            medQuantity = int.Parse(valid2);
            Products med = new Products(medName, medQuantity);
            return med;
        }



        static void RemoveMedicine(List<Products> prdct)
        {
            string name;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t====>  AVAILABLE   STOCK   OF  MEDICINE <===");
            for (int i = 0; i < prdct.Count; i++)
            {

                Console.WriteLine("");
                Console.Write("\t\t\t" + "  Medicine " + " : ");
                Console.WriteLine(prdct[i].medicine);
                Console.Write("\t\t\t" + "  Quantity " + " : ");
                Console.WriteLine(prdct[i].quantity);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t ===> Press any key to Remove the medicine <===");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Enter the name of medicine you want to remove : ");
            name = Console.ReadLine();
            for (int i = 0; i < prdct.Count; i++)
            {
                if (name == prdct[i].medicine)
                {
                    prdct.RemoveAt(i);    // when we pass index then use RemoveAt....... 
                    StoreMedicine(prdct);
                    Console.WriteLine("\t\t\t\tRemoved Successfully");
                    Console.ReadKey();        // otherwise use remove if object is passed.....
                    break;
                }
            }
        }

        static void UpdateMedicine(List<Products> prdct)
        {
            int quan;
            string name;
            string option;
            bool flag = true;
            Console.Write("Enter the name of medicine : ");
            name = Console.ReadLine();
            for (int i = 0; i < prdct.Count; i++)
            {
                if (name == prdct[i].medicine)
                {
                    Console.WriteLine("Medicine :  " + prdct[i].medicine);
                    Console.WriteLine("Quantity :  " + prdct[i].quantity);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("Enter the updated Quantity of the medicine : ");
                    quan = int.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Enter you want to add or sub the quantity from the previous Quantity : ");
                        option = Console.ReadLine();
                        if (option == "add" || option == "Add")
                        {
                            prdct[i].quantity = prdct[i].quantity + quan;
                            StoreMedicine(prdct);
                            flag = true;
                            Console.ReadKey();
                            break;
                        }
                        else if (option == "sub" || option == "Sub")
                        {
                            prdct[i].quantity = prdct[i].quantity - quan;
                            StoreMedicine(prdct);
                            flag = true;
                            Console.ReadKey();
                            break;

                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Invalid Response");
                            Console.ReadKey();
                        }
                    }
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Medicine is not Available");
                Console.ReadKey();
            }
        }

        static User AddStaff()
        {
            string name;
            string pass;
            string role;
            Console.Clear();
            displayMenu();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Ënter the username you want to add : ");
            name = Console.ReadLine();
            Console.Write("Ënter the Passwards of the user : ");
            pass = Console.ReadLine();

            Console.Write("Ënter the role of the user : ");
            role = Console.ReadLine();
            User a = new User(name, pass, role);
            return a;

        }


        static void RemoveStaff(List<User> u)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t ===> Press any key to Remove the Staff <===");
            Console.ReadKey();
            Console.Clear();
            displayMenu();
            string name;
            string password;
            int flag = 1;
            Console.Write("Enter the name of the employe you want to remove :  ");
            name = Console.ReadLine();
            Console.Write("Enter the Password of the employe :  ");
            password = Console.ReadLine();
            for (int i = 0; i < u.Count; i++)
            {
                if (name == u[i].username && password == u[i].password)
                {
                    flag = 1;
                    u.RemoveAt(i);
                    StoreData(u);
                    break;
                }
                else
                {
                    flag = 0;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("\t\t\t\tUser not found try again ");
                Console.ReadKey();

            }
            if (flag == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("\t\t\t\tRemoved Successfully");
                Console.ReadKey();
            }
        }

        static void markAttendence(List<User> u)
        {
            Console.Clear();
            displayMenu();
            for (int i = 0; i < u.Count; i++)
            {
                if (u[i].roles == "Employe")
                {
                    Console.Write("Is User " + u[i].username + " Present : ");
                    u[i].attendence = Console.ReadLine();
                    StoreAttendence(u);
                }
                else if (u[i].roles == "Customer")
                {
                    continue;
                }
                else if (u[i].roles == "Admin")
                {
                    continue;
                }
            }
            Console.Clear();
            displayMenu();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t ===> Here is the Attendence of Employe <===");
            Console.WriteLine("");
            Console.WriteLine("");
            for (int i = 0; i < u.Count; i++)
            {
                if (u[i].roles == "Employe")
                {
                    Console.WriteLine("\t\t\t" + u[i].username + "\t\t" + u[i].attendence);
                    Console.WriteLine("");
                }
                else if (u[i].roles == "Customer")
                {
                    continue;
                }
                else if (u[i].roles == "Admin")
                {
                    continue;
                }
            }
            Console.ReadKey();
        }

        static void StoreAttendence(List<User> u)
        {
            StreamWriter file = new StreamWriter("D:\\2nd semester OOP\\OOP PD\\Week 04\\system\\attendence.txt");
            for (int i = 0; i < u.Count; i++)
            {
                file.Write(u[i].username + ",");
                file.WriteLine(u[i].attendence);
            }
            file.Close();

        }

        static void LoadAttendence(List<User> u)
        {
            string name;
            string attendence;
            string path = "D:\\2nd semester OOP\\OOP PD\\Week 04\\system\\attendence.txt";
            StreamReader file = new StreamReader(path);
            if (File.Exists(path))
            {
                string record;
                while ((record = file.ReadLine()) != null)
                {

                    name = parseData(record, 1);
                    attendence = parseData(record, 2);
                    User a = new User(name, attendence);
                    u.Add(a);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File doesnot Exists");
            }

        }

        static void StoreMedicine(List<Products> prdct)
        {
            StreamWriter file = new StreamWriter("D:\\2nd semester OOP\\OOP PD\\Week 04\\system\\medicine.txt");
            for (int i = 0; i < prdct.Count; i++)
            {
                file.Write(prdct[i].medicine + ",");
                file.WriteLine(prdct[i].quantity);
            }
            file.Close();

        }

        static void LoadMedicine(List<Products> prdct)
        {
            string medName;
            int medQuantity;
            string path = "D:\\2nd semester OOP\\OOP PD\\Week 04\\system\\medicine.txt";
            StreamReader file = new StreamReader(path);
            if (File.Exists(path))
            {
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    medName = parseData(record, 1);
                    medQuantity = int.Parse(parseData(record, 2));
                    Products med = new Products(medName, medQuantity);
                    prdct.Add(med);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File doesnot Exists");
            }

        }

        static bool intChecking(string valid2)
        {
            for (int z = 0; z < valid2.Length; z++)
            {
                if (valid2[z] != '0' && valid2[z] != '1' && valid2[z] != '2' && valid2[z] != '3' && valid2[z] != '4' && valid2[z] != '5' && valid2[z] != '6' && valid2[z] != '7' && valid2[z] != '8' && valid2[z] != '9')
                {
                    return false;
                }
            }
            return true;
        }
    }

}
