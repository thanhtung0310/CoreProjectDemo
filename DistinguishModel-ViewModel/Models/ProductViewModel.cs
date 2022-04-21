using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistinguishModel_ViewModel.Models
{
    public class ProductViewModel
    {
        public int product_id { get; set; }
        public string name { get; set; }
        public Decimal price { get; set; }
        public int rating { get; set; }
        public string brand_name { get; set; }
        public string supplier_name { get; set; }

        public string getRating()
        {
            if (rating == 10)
                return "*****";
            else if (rating >= 8)
                return "****";
            else if (rating >= 6)
                return "***";
            else if (rating >= 4)
                return "**";
            else if (rating >= 2)
                return "*";
            else
                return "";
        }
    }
}
