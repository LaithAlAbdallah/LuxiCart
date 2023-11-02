using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class SellerCreditCard
    {
        public int SellerCreditCardId { get; set; }

        [Required(ErrorMessage ="Please Enter Credit Card Number")]
        public int Number { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime ExpiryDate { get; set; }
        [Required]
        public string? CardHolderName  { get; set; }




        //Relations------------------------Relations-->

        [ForeignKey("SellerInfo")]
        public int SellerInfoId { get; set; }
        public SellerInfo? SellerInfo { get; set; }
    }
}
