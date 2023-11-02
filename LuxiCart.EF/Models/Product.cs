using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public string? Image { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public Decimal Price { get; set; }


        //Relations------------------------Relations-->

        [ForeignKey("ProductParentCategory")]
        public int ProductParentCategoryId { get; set; }
        public ProductParentCategory? ProductParentCategory { get; set; }


        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }
        public ProductCategory? ProductCategory { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        public Seller? Seller { get; set; }
    }
}
