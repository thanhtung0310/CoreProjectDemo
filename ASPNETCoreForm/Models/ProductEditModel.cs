using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreForm.Models
{
    public class ProductEditModel
    {
        public int ID { get; set; }
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public int Rating { get; set; }
    }
}
