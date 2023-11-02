using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class ProofOfIdentity
    {
        public int ProofOfIdentityId { get; set; }
        [Required]
        public int CountryOfIssue { get; set; }
        [Required(ErrorMessage ="Please Enter Your Identity Number")]
        public string? IdentityNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime ExpiryDate { get; set; }
        [Required]
        public string? IdentityImage { get; set; }



        //Relations------------------------Relations-->

        [ForeignKey("TypeOfIdentity")]
        public int TypeOfIdentityId { get; set; }
        public TypeOfIdentity? TypeOfIdentity { get; set; }

        [ForeignKey("SellerInfo")]
        public int SellerInfoId { get; set; }
        public SellerInfo? SellerInfo { get; set; }




    }
}
