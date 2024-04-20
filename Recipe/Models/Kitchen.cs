using System;
using System.Collections.Generic;

namespace Recipe.Models
{
    public partial class Kitchen
    {
        public Kitchen()
        {
            Recipes = new HashSet<Recipe>();
        }

        public int KitchenId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
