﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Models
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string? CategoryName { get; set; }

        //Relations------------------------Relations-->

        public ICollection<Promotion>? Promotion { get; set; }

        public ICollection<ProductParentCategory>? productParentCategories { get; set; }
    }
}
