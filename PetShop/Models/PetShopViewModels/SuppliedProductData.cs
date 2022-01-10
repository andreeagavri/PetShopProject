using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopModel.Models.PetShopViewModels
{
    public class SuppliedProductData
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public bool IsSupplied { get; set; }
    }
}
