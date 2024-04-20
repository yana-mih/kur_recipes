using System;
using System.Collections.Generic;

namespace Recipe.Models
{
    public partial class MainProduct
    {
        public MainProduct()
        {
            MainProductRecipes = new HashSet<MainProductRecipe>();
        }

        public int MainProductId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<MainProductRecipe> MainProductRecipes { get; set; }
    }
}
