using System.Collections.ObjectModel;
using Recipe.Models;
using Recipe.Models.Helper;

namespace Recipe.VM;

public class HotVM
{
    private readonly RecipeContext db = new();

    public HotVM()
    {
        Recipes = new ObservableCollection<RecipeHelper>();

        GetRecipes();
    }

    public ObservableCollection<RecipeHelper> Recipes { get; set; }

    public void GetRecipes()
    {
        var category = db.Categories.Where(c => c.Name == "Горячее").FirstOrDefault();

        var collection = new ObservableCollection<RecipeHelper>();

        var recipesList = db.Recipes.Where(r => r.CategoryId == category.CategoryId).ToList();

        foreach (var recipe in recipesList)
        {
            var savedImage = db.Images.Where(i => i.ImageId == recipe.ImageId).FirstOrDefault();

            var recipeHelper = new RecipeHelper
            {
                RecipeId = recipe.RecipeId,
                NameRecipe = recipe.NameRecipe,
                Description = recipe.Description,
                Ingredients = recipe.Ingredients,
                Kbzy = recipe.Kbzy,
                Time = recipe.Time,
                PersonId = recipe.PersonId,
                CategoryId = recipe.CategoryId,
                KitchenId = recipe.KitchenId,
                TypeOfCookingId = recipe.TypeOfCookingId,
                TypeOfDishId = recipe.TypeOfDishId,
                ImageBytes = savedImage.Image1
            };

            collection.Add(recipeHelper);
        }

        Recipes = new ObservableCollection<RecipeHelper>(collection.Take(6).ToList());
    }
}