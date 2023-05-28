using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_Mclasses_.BL;

namespace system_Mclasses_.DL
{
   public class MUserCrud
    {
        public static List<MUser> user = new List<MUser>();
        public static List<Product> prdct = new List<Product>();

        public static void AddUserIntoList(MUser u)
        {
            MUserCrud.user.Add(u);
        }

        public static void AddProductIntoList(Product p)
        {
            MUserCrud.prdct.Add(p);
        }

        public static void viewMedicine()
        {
            for (int i = 0; i < prdct.Count; i++)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("\t\t\tMedicine Name : " + prdct[i].medicineName);
                Console.WriteLine("\t\t\tMedicine quantity : " + prdct[i].medicineQuantity);
                Console.WriteLine("\t\t\tMedicine price : " + prdct[i].medicinePrice);
                Console.ReadKey();
            }
        }

        public static void RemoveMedicinefromlist(string name)
        {
           
            for (int i = 0; i < prdct.Count; i++)
            {
                if (name == prdct[i].medicineName)
                {
                    prdct.RemoveAt(i);    // when we pass index then use RemoveAt....
                    break;
                }
            }
        }

        public static void viewStaff()
        {
            for (int i = 0; i < user.Count; i++)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("\t\t\tUserName  : " + user[i].username);
                Console.WriteLine("\t\t\tPassword : " + user[i].password);
                Console.WriteLine("\t\t\tRole : " + user[i].role);
                Console.ReadKey();
            }
        }

        public static bool removeStaffFromList(string name,string password)
        {
            bool flag = true;

            for (int i = 0; i < user.Count; i++)
            {
                if (name == user[i].username && password == user[i].password)
                {
                    flag = true;
                    user.RemoveAt(i);

                    break;
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
