namespace Recipe.Models;

public class TypeOfDish
{
    public TypeOfDish()
    {
        Recipes = new HashSet<Recipe>();
    }

    public int TypeOfDish1 { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; set; }
}