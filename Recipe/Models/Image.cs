namespace Recipe.Models;

public class Image
{
    public Image()
    {
        Recipes = new HashSet<Recipe>();
    }

    public int ImageId { get; set; }
    public byte[]? Image1 { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; }
}