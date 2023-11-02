using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
	public class ProductItem
	{
		public int ProductItemId { get; set; }
        [Required]
        public int QuantityInStock { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public string? Color { get; set; }

        public string? ItemImage { get; set; }
        
        public string? Size { get; set; }


        //Relations------------------------Relations-->

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }   



    }
}
