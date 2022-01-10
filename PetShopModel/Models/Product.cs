using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopModel.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string ProductType { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public string Image { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<SuppliedProduct> SuppliedProducts { get; set; }
    }
}
