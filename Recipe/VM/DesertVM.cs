using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Recipe.Models;
using Recipe.Models.Helper;

namespace Recipe.VM
{
    public class DesertVM
    {
        private RecipeContext db = new RecipeContext();
        public ObservableCollection<RecipeHelper> Recipes { get; set; }
        public DesertVM()
        {
            Recipes = new ObservableCollection<RecipeHelper>();

            GetRecipes();
        }

        public void GetRecipes()
        {
            Category? category = db.Categories.Where(c => c.Name == "Десерт").FirstOrDefault();

            ObservableCollection<RecipeHelper> collection = new ObservableCollection<RecipeHelper>();

            var recipesList = db.Recipes.Where(r => r.CategoryId == category.CategoryId).ToList();

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