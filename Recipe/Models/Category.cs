namespace Recipe.Models;

public class Category
{
    public Category()
    {
        Recipes = new HashSet<Recipe>();
    }

    public int CategoryId { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; set; }
}