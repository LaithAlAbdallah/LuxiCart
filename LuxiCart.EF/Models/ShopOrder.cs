using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class ShopOrder
    {
        public int ShopOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }

        //Relations------------------------Relations-->


        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }


        [ForeignKey("ShippingMethod")]
        public int ShippingMethodId { get; set; }
        public ShippingMethod? ShippingMethod { get; set; }


        [ForeignKey("OrderStatus")]
        public int OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
    }
}
