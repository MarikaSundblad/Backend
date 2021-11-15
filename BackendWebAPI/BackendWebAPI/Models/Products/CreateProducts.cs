using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebAPI.Models.Products
{
    public class CreateProducts
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Price { get; set; }

    }
}
