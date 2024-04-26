using System.Collections.ObjectModel;
using Recipe.Models;
using Recipe.Models.Helper;

namespace Recipe.VM;

public class BaseRecipeVM
{
    private readonly RecipeContext db = new();

    public BaseRecipeVM()
    {
        Recipes = new ObservableCollection<RecipeHelper>();

        GetRecipes();
    }

    public ObservableCollection<RecipeHelper> Recipes { get; set; }

    public ObservableCollection<RecipeHelper> GetBigSearchResult(List<Models.Recipe> recipesList)
    {
        var collection = new ObservableCollection<RecipeHelper>();

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

        return new ObservableCollection<RecipeHelper>(collection.Take(6).ToList());
    }

    public ObservableCollection<RecipeHelper> GetSearhResult(string recipename)
    {
        var collection = new ObservableCollection<RecipeHelper>();

        var recipesList = db.Recipes.Where(r => r.NameRecipe.ToLower().Contains(recipename.ToLower())).ToList();

        foreach (var recipe in recipesList)
        {
            var savedImage = db.Images.FirstOrDefault(i => i.ImageId == recipe.ImageId);

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
                ImageBytes = savedImage?.Image1
            };

            collection.Add(recipeHelper);
        }

        return collection;
    }


    public void GetRecipes()
    {
        var collection = new ObservableCollection<RecipeHelper>();

        var recipesList = db.Recipes.ToList();

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