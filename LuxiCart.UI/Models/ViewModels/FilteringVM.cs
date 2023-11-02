﻿using LuxiCart.EF.Models;

namespace LuxiCart.UI.Models.ViewModels
{
    public class FilteringVM
    {
        public List<ProductParentCategory>? productParentCategories { get; set; }
        public List<ProductCategory>? productCategories { get; set; }
        public List<Product>? products { get; set; }
    }
}
