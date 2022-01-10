using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopModel.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public DateTime OrderDate { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
    }
}
