using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class SellerInfo
    {
        public int SellerInfoId { get; set; }

        [Required(ErrorMessage = "Please Enter Your First Name")]
        [MaxLength(10, ErrorMessage = "Enter Your First Name Only")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Middle Name")]
        [MaxLength(10, ErrorMessage = "Enter Your Middle Name Only")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Last Name")]
        [MaxLength(15, ErrorMessage = "Enter Your Last Name Only")]
        public string? LastName { get; set; }
        [Required]
        public int CountryOfCitizenship { get; set; }
        [Required]
        public int CountryOfBirth { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        //Relations------------------------Relations-->

        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        public Seller? Seller { get; set; }

        public ProofOfIdentity? ProofOfIdentity { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }


    }
}
