using Recipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Models.Helper;
using Recipe.Helper;

namespace Recipe.VM
{
    public class BaseRecipeVM
    {
        private RecipeContext db = new RecipeContext();
        public ObservableCollection<RecipeHelper> Recipes { get; set; }
        public BaseRecipeVM()
        {
            Recipes = new ObservableCollection<RecipeHelper>();

            GetRecipes();
        }

        public ObservableCollection<RecipeHelper> GetBigSearchResult(List<Models.Recipe> recipesList)
        {
            ObservableCollection<RecipeHelper> collection = new ObservableCollection<RecipeHelper>();

            foreach (var recipe in recipesList)
            {
                var savedImage = db.Images.Where(i => i.ImageId == recipe.ImageId).FirstOrDefault();

                RecipeHelper recipeHelper = new RecipeHelper
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
            ObservableCollection<RecipeHelper> collection = new ObservableCollection<RecipeHelper>();

            var recipesList = db.Recipes.Where(r => r.NameRecipe.ToLower().Contains(recipename.ToLower())).ToList();

            foreach (var recipe in recipesList)
            {
                var savedImage = db.Images.FirstOrDefault(i => i.ImageId == recipe.ImageId);

                RecipeHelper recipeHelper = new RecipeHelper
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
            ObservableCollection<RecipeHelper> collection = new ObservableCollection<RecipeHelper>();

            var recipesList = db.Recipes.ToList();

            foreach (var recipe in recipesList)
            {
                var savedImage = db.Images.Where(i => i.ImageId == recipe.ImageId).FirstOrDefault();

                RecipeHelper recipeHelper = new RecipeHelper
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
}
