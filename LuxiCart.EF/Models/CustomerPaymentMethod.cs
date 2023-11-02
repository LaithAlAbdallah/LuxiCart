using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class CustomerPaymentMethod
    {
        public int CustomerPaymentMethodId { get; set; }
        [Required]
        public string? Provider { get; set; }
        [Required(ErrorMessage = "Please Enter Credit Card Number")]
        [MaxLength(16, ErrorMessage = "It should be 16 digits!")]
        public int CardNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: yyyy-MM}")]
        public DateTime ExpiryDate { get; set; }
        [Required]
        public string? CardHolderName { get; set; }
        public bool IsDefault { get; set; }


        //Relations------------------------Relations-->

        [ForeignKey("Customer")]
        public int? CustomerId { get; set;}
        public Customer? Customer { get; set; }


        [ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }
        public PaymentType? PaymentType { get; set; }
    }
}
