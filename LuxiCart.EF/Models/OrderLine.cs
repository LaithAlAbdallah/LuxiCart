using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //Relations------------------------Relations-->

        [ForeignKey("ProductItem")]
        public int ProductItemId { get; set; }
        public ProductItem? ProductItem { get; set; }


        [ForeignKey("ShopOrder")]
        public int ShopOrderId { get; set; }
        public ShopOrder? ShopOrder { get; set; }
    }
}
