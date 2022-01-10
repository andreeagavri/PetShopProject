using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopModel.Models.PetShopViewModels
{
    public class SupplierIndexData
    {
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
