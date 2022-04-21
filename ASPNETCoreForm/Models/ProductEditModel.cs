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
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
                
        [Required]
        public decimal Rate { get; set; }
                
        [Required]
        public int Rating { get; set; }
    }
}
