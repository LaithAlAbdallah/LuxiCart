using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class ProductParentCategory
    {
        public int ProductParentCategoryId { get; set; }
        public string? ParentCategoryName { get; set; }
        public string? ParentCategoryImage { get; set; }


        //Relations------------------------Relations-->

        public ICollection<ProductCategory>? productCategories { get; set; }
    }
}
