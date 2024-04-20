using System;
using System.Collections.Generic;

namespace Recipe.Models
{
    public partial class TypeOfDish
    {
        public TypeOfDish()
        {
            Recipes = new HashSet<Recipe>();
        }

        public int TypeOfDish1 { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
