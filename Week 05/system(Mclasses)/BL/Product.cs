using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_Mclasses_.BL
{
   public class Product
    {
        public string medicineName;
        public int medicineQuantity;
        public int medicinePrice;

        public Product(string name, int quantity, int price)
        {
            this.medicineName = name;
            this.medicineQuantity = quantity;
            this.medicinePrice = price;
        }
    }
}
