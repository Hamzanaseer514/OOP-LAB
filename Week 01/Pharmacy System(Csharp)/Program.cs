using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SignIn___SignUp_menu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            int index1 = 0;
            int userCount = 1;
            int arrsize = 15;
            string[] username = new string[15];
            string[] passwards = new string[15];
            string[] roles = new string[15];
            string[] medicine = new string[15];
            int[] quantity = new int[15];
            string[] attendence = new string[15];
            username[0] = "hamza123";
            passwards[0] = "abcd";
            roles[0] = "Admin";
            LoadData(ref userCount, username, passwards, roles);
            LoadMedicine(medicine, quantity, ref index1);
            LoadAttendence(userCount, username, attendence);
            int option = 0;
            // Menu();
            while (option != 3)
            {
                Console.Clear();
                displayMenu();
                option = Menu();
                if (option == 1)
                {
                    Console.Clear();
                    displayMenu();
                    string password;
                    string name;
                    string role = "Admin";
                    Console.Write("Ënter the username Employe/Customer  : ");
                    name = Console.ReadLine();
                    Console.Write("Enter the passward : ");
                    password = Console.ReadLine();
                    while (role == "Admin")
                    {
                        Console.Write("Enter the role : ");
                        role = Console.ReadLine();
                        if (role == "Admin")
                        {
                            Console.WriteLine("You cannot signup as an Admin");
                            Console.ReadKey();
                        }

                    }
                    bool isValid = signup(name, password, role, username, ref index, ref userCount, passwards, ref arrsize, roles);
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
                    Console.Clear();
                    displayMenu();
                    string password;
                    string name;
                    string role;
                    Console.Write("Ënter the username  : ");
                    name = Console.ReadLine();
                    Console.Write("Enter the passward : ");
                    password = Console.ReadLine();

                    role = Signin(name, password, userCount, username, passwards, roles);
                    if (role == "Admin")
                    {
                        AdminInterface(medicine, quantity, ref index1,ref userCount,username,passwards,roles,attendence);

                    }
                    else if (role == "Employe")
                    {
                        Console.WriteLine("NOT IMPLEMENTED");
                        Console.ReadKey();
                    }
                    else if (role == "Customer")
                    {
                        Console.WriteLine("NOT IMPLEMENTED");
                        Console.ReadKey();
                    }
                    else if (role == "Undefined")
                    {
                        Console.WriteLine("You have Entered Wrong id and password !");
                        Console.ReadKey();
                    }

                }
            }

        }
        static int Menu()
        {
            int option;
            Console.WriteLine("1.  SignUp");
            Console.WriteLine("2.  SignIn");
            Console.WriteLine("3.  Exit");
            string valid2;
            Console.Write("Enter the Option : ");
            valid2 = (Console.ReadLine());
            while (!(intChecking(valid2)))
            {
                Console.WriteLine("INVALID RESPONSE TRY AGAIN");
                Console.Write("Enter the Option : ");
                valid2 = (Console.ReadLine());
            }

            option = int.Parse(valid2);
            return option;
        }

        static bool signup(string name, string password, string role, string[] username, ref int index, ref int userCount, string[] passwards, ref int arrsize, string[] roles)
        {
            bool isPresent = false;

            for (int i = 0; i < userCount; i++)
            {
                if (username[i] == name && passwards[i] == password)
                {
                    isPresent = true;
                    break;
                }
            }
            if (isPresent == true)
            {
                return false;
            }
            else if (userCount < arrsize)
            {
                username[userCount] = name;
                passwards[userCount] = password;
                roles[userCount] = role;
                userCount++;
                StoreData(userCount, username, passwards, roles);
                return true;
            }
            else
            {
                return false;
            }
        }

        static string Signin(string name, string password, int userCount, string[] username, string[] passwards, string[] roles)
        {
            for (int index = 0; index < userCount; index++)
            {
                if (username[index] == name && passwards[index] == password)
                {
                    return roles[index];
                }
            }

            return "Undefined";
        }

        static void StoreData(int userCount, string[] username, string[] passwards, string[] roles)
        {
            StreamWriter file = new StreamWriter("D:\\2nd semester OOP\\OOP PD\\Week 01\\Pharmacy System(Csharp)\\Data.txt");
            for (int i = 1; i < userCount; i++)
            {
                file.Write(username[i] + ",");
                file.Write(passwards[i] + ",");
                file.WriteLine(roles[i]);
            }
            file.Close();

        }

        static void LoadData(ref int userCount, string[] username, string[] passwards, string[] roles)
        {
            string path = "D:\\2nd semester OOP\\OOP PD\\Week 01\\Pharmacy System(Csharp)\\Data.txt";
            StreamReader file = new StreamReader(path);
            if (File.Exists(path))
            {
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    username[userCount] = parseData(record, 1);
                    passwards[userCount] = parseData(record, 2);
                    roles[userCount] = parseData(record, 3);
                    userCount++;
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
            string valid2;
            Console.Write("Enter the Option : ");
            valid2 = (Console.ReadLine());
            while (!(intChecking(valid2)))
            {
                Console.WriteLine("INVALID RESPONSE TRY AGAIN");
                Console.Write("Enter the Option : ");
                valid2 = (Console.ReadLine());
            }

            option = int.Parse(valid2);
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

        static void AdminInterface(string[] medicine, int[] quantity, ref int index1, ref int userCount, string[] username, string[] passwards, string[] roles,string[] attendence)
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
                        AddMedicine(medicine, quantity, ref index1);
                    }
                    if (option == 2)
                    {
                        ViewMedicine(medicine, quantity, index1);

                    }
                    if (option == 3)
                    {
                        RemoveMedicine(medicine, quantity, ref index1);

                    }

                    if(option == 4)
                    {
                        UpdateMedicine(medicine, quantity, index1);

                    }
                    if (option == 5)
                    {
                        AddStaff(ref userCount, username, passwards, roles);

                    }
                    if(option == 7)
                    {
                        RemoveStaff(ref userCount, username, passwards, roles);
                    }
                    if(option == 6)
                    {
                        ViewStaff(userCount, username, passwards, roles);
                    }
                    if(option == 8)
                    {
                        markAttendence(userCount, username, passwards, roles, attendence);
                    }
                    if(option == 9)
                    {
                        exists = true;
                    }
                    if(option > 9 || option < 1)
                    {
                        Console.WriteLine("\t\t\t\t ===> Please Enter the Correct option <===");
                        Console.ReadKey();
                        continue;
                    }
                }

            }
        }

        static void AddMedicine(string[] medicine, int[] quantity, ref int index1)
        {
            string answer;
            bool exist = false;
            while (exist == false)
            {
                Console.Clear();
                displayMenu();
                Console.Write("Are you want to add the medicine yes/no : ");
                answer = Console.ReadLine();
                if (answer == "yes" || answer == "Yes")
                {
                    string valid1;
                    string valid2;
                    Console.Write("Enter the name of Medicine : ");
                    valid1 = Console.ReadLine();
                    while (!(stringChecking(valid1)))
                    {
                        Console.WriteLine("INVALID RESPONSE TRY AGAIN");
                        Console.Write("Enter the name of Medicine : ");
                        valid1 = Console.ReadLine();
                    }
                    medicine[index1] = valid1;

                    Console.Write("Enter the quantity of Medicine : ");
                    valid2  = (Console.ReadLine());
                    while (!(intChecking(valid2)))
                    {
                        Console.WriteLine("INVALID RESPONSE TRY AGAIN");
                        Console.Write("Enter the quantity of Medicine : ");
                        valid2 = (Console.ReadLine());
                    }

                    quantity[index1] = int.Parse(valid2);
                    index1++;
                    StoreMedicine(medicine, quantity, index1);
                }

                else if (answer == "no" || answer == "No")
                {
                    exist = true;
                }
                else if (answer != "yes" || answer != "Yes" || answer != "no" || answer != "No")
                {
                    Console.WriteLine("\t\t\t\t ===>  Please Enter the specific option <===");
                    Console.ReadKey();
                    continue;
                }
            }
        }

       

        static void ViewMedicine(string[] medicine, int[] quantity, int index1)
        {
            for (int i = 0; i < index1; i++)
            {
                Console.Clear();
                displayMenu();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("\t\t\tMedicine no " + i + " : ");
                Console.WriteLine(medicine[i]);
                Console.WriteLine("");
                Console.Write("\t\t\tQuantity of Medicine " + i + " : ");
                Console.WriteLine(quantity[i]);
                Console.ReadKey();
            }
        }

        static void RemoveMedicine(string[] medicine, int[] quantity, ref int index1)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t====>  AVAILABLE   STOCK   OF  MEDICINE <===");
            for (int i = 0; i < index1; i++)
            {

                Console.WriteLine("");
                Console.Write("\t\t\t" + i + ".  Medicine " + " : ");
                Console.WriteLine(medicine[i]);
                Console.Write("\t\t\t" + i + ".  Quantity " + " : ");
                Console.WriteLine(quantity[i]);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t ===> Press any key to Remove the medicine <===");
            Console.ReadKey();
            Console.Clear();
            displayMenu();
            string name;
            string valid1;
            Console.Write("Enter the name of medicine you want to  remove : ");
            valid1 = Console.ReadLine();
            while (!(stringChecking(valid1)))
            {
                Console.WriteLine("INVALID RESPONSE TRY AGAIN");
                Console.Write("Enter the name of medicine you want to  remove : ");
                valid1 = Console.ReadLine();
            }
            name = valid1;
            
            int k = 0;
            while (k < index1)
            {
                if (name == medicine[k])
                {
                    for (int j = k; j < index1; j++)
                    {
                        medicine[j] = medicine[j + 1];
                        quantity[j] = quantity[j + 1];
                        Console.WriteLine("\t\t\t\t ===>  REMOVED  SUCCESSFULLY  <===");
                        Console.ReadKey();
                        break;
                    }
                    index1--;
                }
                else
                {
                    k++;
                }

            }

        }

        static void StoreMedicine(string[] medicine, int[] quantity,int index1)
        {
            StreamWriter file = new StreamWriter("D:\\2nd semester OOP\\OOP PD\\Week 01\\Pharmacy System(Csharp)\\medicine.txt");
            for (int i = 0; i < index1; i++)
            {
                file.Write(medicine[i] + ",");
                file.WriteLine(quantity[i]);
            }
            file.Close();

        }

        static void LoadMedicine(string[] medicine, int[] quantity, ref int index1)
        {
            string path = "D:\\2nd semester OOP\\OOP PD\\Week 01\\Pharmacy System(Csharp)\\medicine.txt";
            StreamReader file = new StreamReader(path);
            if (File.Exists(path))
            {
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    medicine[index1] = parseData(record, 1);
                    quantity[index1] = int.Parse(parseData(record, 2));
                    index1++;
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File doesnot Exists");
            }

        }

        static void AddStaff(ref int userCount, string[] username, string[] passwards, string[] roles)
        {
            Console.Clear();
            displayMenu();
            Console.WriteLine("");
            Console.WriteLine("");
            string valid1;
            Console.Write("Ënter the username you want to add : ");
            valid1 = Console.ReadLine();
            while (!(stringChecking(valid1)))
            {
                Console.WriteLine("INVALID RESPONSE TRY AGAIN");
                Console.Write("Ënter the username you want to add : ");
                valid1 = Console.ReadLine();
            }
              username[userCount] = valid1;
            
            
            Console.Write("Ënter the Passwards of the user : ");
            passwards[userCount] = Console.ReadLine();  
            
            Console.Write("Ënter the role of the user : ");
            roles[userCount] = Console.ReadLine();

            userCount++;
            StoreData(userCount, username, passwards, roles);

        }

        static void ViewStaff(int userCount, string[] username, string[] passwards, string[] roles)
        {
            for (int i = 0; i < userCount; i++)
            {
                Console.Clear();
                displayMenu();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("\t\t\tUser Name " + i + " :  \t\t");
                Console.WriteLine(username[i]);
                Console.WriteLine("");
                Console.Write("\t\t\tPassward " + i + " : \t\t");
                Console.WriteLine(passwards[i]);
                Console.WriteLine("");
                Console.Write("\t\t\tRole " + i + " : \t\t");
                Console.WriteLine(roles[i]);
                Console.ReadKey();
            }
        }

        static void RemoveStaff(ref int userCount, string[] username, string[] passwards, string[] roles)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t====>  AVAILABLE   STAFF  <===");
            for (int i = 0; i < userCount; i++)
            {

                Console.Write("\t\t\tUser Name " + i + " :  \t\t");
                Console.WriteLine(username[i]);
                Console.Write("\t\t\tPassward " + i + " : \t\t");
                Console.WriteLine(passwards[i]);
                Console.Write("\t\t\tRole " + i + " : \t\t");
                Console.WriteLine(roles[i]);
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t ===> Press any key to Remove the Staff <===");
            Console.ReadKey();
            Console.Clear();
            displayMenu();
            string name;
            string password;
            string valid1;
            Console.Write("Ënter the username of the Employe : ");
            valid1 = Console.ReadLine();
            while (!(stringChecking(valid1)))
            {
                Console.WriteLine("INVALID RESPONSE TRY AGAIN");
                Console.Write("Ënter the username of the Employe : ");
                valid1 = Console.ReadLine();
            }
            name = valid1;
            Console.Write("Enter the password of Employe : ");
            password = Console.ReadLine();
            int k = 0;
            while (k < userCount)
            {
                if (name == username[k] && password == passwards[k])
                {
                    for (int j = k; j < userCount; j++)
                    {
                        username[j] = username[j + 1];
                        passwards[j] = passwards[j + 1];
                      
                        
                    }
                    userCount--;
                    Console.WriteLine("\t\t\t\t ===>  REMOVED  SUCCESSFULLY  <===");
                    Console.ReadKey();
                }
                else
                {
                    k++;
                }

            }
            StoreData(userCount, username, passwards, roles);
        }

       static void markAttendence(int userCount, string[] username, string[] passwards, string[] roles,string[] attendence)
        {
            Console.Clear();
            displayMenu();
            for (int i = 0; i < userCount; i++)
            {
                if (roles[i] == "Employe")
                {
                    Console.Write("Is User " + username[i] + " Present : ");
                
                    attendence[i] = Console.ReadLine();
                    StoreAttendence(userCount, username, attendence);
                }
                else if (roles[i] == "Customer")
                {
                    continue;
                }
                else if (roles[i] == "Admin")
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
            for (int i = 0; i < userCount; i++)
            {
                if (roles[i] == "Employe")
                {
                    Console.WriteLine("\t\t\t" + username[i] + "\t\t" + attendence[i]);
                    Console.WriteLine("");
                }
                else if (roles[i] == "Customer")
                {
                    continue;
                }
                else if (roles[i] == "Admin")
                {
                    continue;
                }
            }
            Console.ReadKey();
        }

        static void StoreAttendence(int userCount, string[] username,string[] attendence)
        {
            StreamWriter file = new StreamWriter("D:\\2nd semester OOP\\OOP PD\\Week 01\\Pharmacy System(Csharp)\\attendence.txt");
            for (int i = 0; i < userCount; i++)
            {
                file.Write(username[i] + ",");
                file.WriteLine(attendence[i]);
            }
            file.Close();

        }

        static void LoadAttendence(int userCount, string[] username, string[] attendence)
        {
            string path = "D:\\2nd semester OOP\\OOP PD\\Week 01\\Pharmacy System(Csharp)\\attendence.txt";
            StreamReader file = new StreamReader(path);
            if (File.Exists(path))
            {
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    username[userCount] = parseData(record, 1);
                    attendence[userCount] = parseData(record, 2);
                    userCount++;
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File doesnot Exists");
            }

        }

        static void UpdateMedicine(string[] medicine, int[] quantity, int index1)
        {
            int quan;
            string name;
            string option;
            bool flag = true;
            Console.Write("Enter the name of medicine : ");
            name = Console.ReadLine();
            for (int i = 0; i < index1; i++)
            {
                if(name == medicine[i])
                {
                    Console.WriteLine("Medicine :  " + medicine[i]);
                    Console.WriteLine("Quantity :  " + quantity[i]);
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
                            quantity[i] = quantity[i] + quan;
                            StoreMedicine(medicine, quantity, index1);
                            flag = true;
                            break;
                        }
                        else if (option == "sub" || option == "Sub")
                        {
                            quantity[i] = quantity[i] - quan;
                            StoreMedicine(medicine, quantity, index1);
                            flag = true;

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
            if(flag == false)
            {
                Console.WriteLine("Medicine is not Available");
                Console.ReadKey();
            }
        }

       static bool stringChecking(string valid1)
        {
            for (int z = 0; z < valid1.Length; z++)
            {
                if (valid1[z] == '0' || valid1[z] == '1' || valid1[z] == '2' || valid1[z] == '3' || valid1[z] == '4' || valid1[z] == '5' || valid1[z] == '6' || valid1[z] == '7' || valid1[z] == '8' || valid1[z] == '9')
                {
                    return false;
                }
            }
            return true;
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




