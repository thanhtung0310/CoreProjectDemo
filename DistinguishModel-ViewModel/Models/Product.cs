using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistinguishModel_ViewModel.Models
{
    public class Product
    {
        public int product_id { get; set; }
        public string name { get; set; }
        public Decimal price { get; set; }
        public int rating { get; set; }
        public Brand Brand { get; set; }
        public Supplier Supplier { get; set; }
    }
}
