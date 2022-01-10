using System;
using System.ComponentModel.DataAnnotations;
namespace PetShopModel.Models.LibraryViewModels
{
    public class OrderGroup
    {
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public int ProductCount { get; set; }
    }
}
