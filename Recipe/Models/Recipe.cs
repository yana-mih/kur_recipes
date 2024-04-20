using System;
using System.Collections.Generic;

namespace Recipe.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            MainProductRecipes = new HashSet<MainProductRecipe>();
        }

        public int RecipeId { get; set; }
        public string NameRecipe { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Ingredients { get; set; } = null!;
        public string Kbzy { get; set; } = null!;
        public string Time { get; set; } = null!;
        public int PersonId { get; set; }
        public int CategoryId { get; set; }
        public int KitchenId { get; set; }
        public int TypeOfCookingId { get; set; }
        public int TypeOfDishId { get; set; }
        public int? ImageId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Image? Image { get; set; }
        public virtual Kitchen Kitchen { get; set; } = null!;
        public virtual Person Person { get; set; } = null!;
        public virtual TypeOfCooking TypeOfCooking { get; set; } = null!;
        public virtual TypeOfDish TypeOfDish { get; set; } = null!;
        public virtual ICollection<MainProductRecipe> MainProductRecipes { get; set; }
    }
}
