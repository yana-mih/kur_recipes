using System;
using System.Collections.Generic;

namespace Recipe.Models
{
    public partial class MainProductRecipe
    {
        public int MainProductRecipeId { get; set; }
        public int RecipeId { get; set; }
        public int MainProductId { get; set; }

        public virtual MainProduct MainProduct { get; set; } = null!;
        public virtual Recipe Recipe { get; set; } = null!;
    }
}
