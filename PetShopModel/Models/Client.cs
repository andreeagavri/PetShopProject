﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopModel.Models
{
    public class Client
    {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int ClientID { get; set; }
            public string Name { get; set; }
            public string Adress { get; set; }
            public DateTime BirthDate { get; set; }
            public ICollection<Order> Orders { get; set; }
        
    }
}