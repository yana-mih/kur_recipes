namespace Recipe.Models;

public class MainProduct
{
    public MainProduct()
    {
        MainProductRecipes = new HashSet<MainProductRecipe>();
    }

    public int MainProductId { get; set; }
    public string? Name { get; set; }

    public virtual ICollection<MainProductRecipe> MainProductRecipes { get; set; }
}