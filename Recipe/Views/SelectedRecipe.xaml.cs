using System.Windows;
using Recipe.Helper;
using Recipe.Models;
using Recipe.Models.Helper;

namespace Recipe.Views;

public partial class SelectedRecipe : Window
{
    private readonly RecipeContext db = new();

    public SelectedRecipe(RecipeHelper currPecipe)
    {
        InitializeComponent();
        var recipeId = currPecipe.RecipeId;

        var mainprod1 = db.MainProductRecipes
            .Where(mp => mp.RecipeId == recipeId).FirstOrDefault();

        var mainProduct =
            db.MainProducts.Where(m => m.MainProductId == mainprod1.MainProductId).FirstOrDefault();

        var person = db.People.Where(p => p.PersonId == currPecipe.PersonId).FirstOrDefault();

        var kitchen = db.Kitchens.Where(k => k.KitchenId == currPecipe.KitchenId).FirstOrDefault();

        var typeOfCooking = db.TypeOfCookings.Where(k => k.TypeOfCookingId == currPecipe.TypeOfCookingId)
            .FirstOrDefault();

        var typeOfDish = db.TypeOfDishes.Where(k => k.TypeOfDish1 == currPecipe.TypeOfDishId).FirstOrDefault();


        BlockAuthor.Text = person.FirstName;
        BlockDescryption.Text = currPecipe.Description;
        BlockIngredients.Text = currPecipe.Ingredients;
        BlockKBZY.Text = currPecipe.Kbzy;

        BlockKitchen.Text = kitchen.Name;
        BlockNameRecipe.Text = currPecipe.NameRecipe;
        BlockTime.Text = currPecipe.Time;

        BlockType.Text = typeOfCooking.Name;

        BlockType2.Text = typeOfDish.Name;
        BlockMajorIngr.Text = mainProduct.Name;

        SelectedImage.Source = ImgHelper.ByteArrayToImage(currPecipe.ImageBytes);
    }

    private void ButtonZakuski_OnClick(object sender, RoutedEventArgs e)
    {
        var zakuski = new Zakuski();
        zakuski.Show();
        Close();
    }

    private void ButtonSalads_OnClick(object sender, RoutedEventArgs e)
    {
        var salat = new Salat();
        salat.Show();
        Close();
    }

    private void ButtonHot_OnClick(object sender, RoutedEventArgs e)
    {
        var gorahge = new Gorahge();
        gorahge.Show();
        Close();
    }

    private void ButtonSoups_OnClick(object sender, RoutedEventArgs e)
    {
        var sup = new Sup();
        sup.Show();
        Close();
    }

    private void ButtonVipechka_OnClick(object sender, RoutedEventArgs e)
    {
        var vipechka = new Vipechka();
        vipechka.Show();
        Close();
    }

    private void ButtonDeserts_OnClick(object sender, RoutedEventArgs e)
    {
        var deserts = new Desert();
        deserts.Show();
        Close();
    }

    private void ButtonSouses_OnClick(object sender, RoutedEventArgs e)
    {
        var us = new Souse();
        us.Show();
        Close();
    }

    private void ButtonToRecipes_OnClick(object sender, RoutedEventArgs e)
    {
        var recipes = new Recipes();
        recipes.Show();
        Close();
    }

    private void ButtonToGeneral_OnClick(object sender, RoutedEventArgs e)
    {
        var mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void ButtonAddNewRecipe_OnClick(object sender, RoutedEventArgs e)
    {
        if (App.CurrentUser != null)
        {
            var dobavlenie = new Dobavlenie();
            dobavlenie.Show();
            Close();
        }
        else
        {
            MessageBox.Show("Для добавления рецепта нужно войти в профиль!");
        }
    }

    private void ButtonToProfile_OnClick(object sender, RoutedEventArgs e)
    {
        if (App.CurrentUser != null)
        {
            var profile = new Profile2();
            profile.Show();
            Close();
        }
        else
        {
            var profile = new Profile();
            profile.Show();
            Close();
        }
    }
}