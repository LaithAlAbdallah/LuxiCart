using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class CustomerReview
    {
        public int CustomerReviewId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }


        //Relations------------------------Relations-->


        [ForeignKey("OrderLine")]
        public int OrderLineId { get; set; }
        public OrderLine? OrderLine { get; set; }

    }
}
