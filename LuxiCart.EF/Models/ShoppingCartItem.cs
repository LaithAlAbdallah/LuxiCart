using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public int Quantity { get; set; }


        //Relations------------------------Relations-->

        [ForeignKey("ShoppingCart")]
        public int ShoppingCartId { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }

        [ForeignKey("ProductItem")]
        public int ProductItemId { get; set; }
        public ProductItem? ProductItem { get; set; }
    }
}
