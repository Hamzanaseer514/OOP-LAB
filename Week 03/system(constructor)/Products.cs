using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_constructor_.BL
{
    class Products
    {
        public Products(string medName,int medQuantity)
        {
            this.medicine = medName;
            this.quantity = medQuantity;
        }

        public void ViewMedicine()
        {
                Console.Write("\t\t\tMedicine no " + " : ");
                Console.WriteLine(this.medicine);
                Console.WriteLine("");
                Console.Write("\t\t\tQuantity of Medicine " + " : ");
                Console.WriteLine(this.quantity);
                Console.ReadKey();
            
        }

        public string medicine;
        public int quantity;
    }
}
