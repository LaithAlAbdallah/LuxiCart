using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? ApplicationUserId { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual Seller? Seller { get; set; }
    }
}
