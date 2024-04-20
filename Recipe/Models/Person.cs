using System;
using System.Collections.Generic;

namespace Recipe.Models
{
    public partial class Person
    {
        public Person()
        {
            Recipes = new HashSet<Recipe>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
