namespace Recipe.Models;

public class Kitchen
{
    public Kitchen()
    {
        Recipes = new HashSet<Recipe>();
    }

    public int KitchenId { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; set; }
}