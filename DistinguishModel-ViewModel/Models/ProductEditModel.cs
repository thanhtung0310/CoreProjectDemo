using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DistinguishModel_ViewModel.Models
{
    public class ProductEditModel
    {
        public int product_id { get; set; }
        [Required(ErrorMessage = "Product Name is Required")]
        [Display(Name = "Product Name")]
        public string name { get; set; }
        public Decimal price { get; set; }
        public int rating { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public int brand_id { get; set; }
        public int supplier_id { get; set; }
    }
}
