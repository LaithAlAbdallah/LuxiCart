using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        [Required]
        public string? PromotionName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal DiscountRate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Relations------------------------Relations-->

        public ICollection<ProductCategory>? productCategory { get; set; }
    }
}
