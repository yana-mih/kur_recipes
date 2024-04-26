namespace Recipe.Models;

public class TypeOfCooking
{
    public TypeOfCooking()
    {
        Recipes = new HashSet<Recipe>();
    }

    public int TypeOfCookingId { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; set; }
}