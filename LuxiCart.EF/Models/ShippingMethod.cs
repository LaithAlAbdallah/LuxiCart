using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class ShippingMethod
    {
        public int ShippingMethodId { get; set; }
        [Required]
        public string? ShippingMethodName { get; set; }
        [Required]
        public decimal ShippingPrice { get; set; }
    }
}
