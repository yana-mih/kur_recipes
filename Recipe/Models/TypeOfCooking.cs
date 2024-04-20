﻿using System;
using System.Collections.Generic;

namespace Recipe.Models
{
    public partial class TypeOfCooking
    {
        public TypeOfCooking()
        {
            Recipes = new HashSet<Recipe>();
        }

        public int TypeOfCookingId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
