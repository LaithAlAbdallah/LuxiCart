using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        public string? City { get; set; }
        public int PostalCode { get; set; }
        [Required]
        public string? StreetName { get; set; }
        [Required]
        public int UnitNumber { get; set; }
        [Required]
        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }


        //Relations------------------------Relations-->

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country? Country { get; set; }

        public ICollection<Customer>? Customer { get; set; }
    }
}
