using System.Windows;
using Microsoft.EntityFrameworkCore;
using Recipe.Models;

namespace Recipe.Views;

/// <summary>
///     Логика взаимодействия для Recipes.xaml
/// </summary>
public partial class Recipes : Window
{
    private readonly RecipeContext db = new();

    public Recipes()
    {
        InitializeComponent();
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

    private void ButtonSearch_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(TextBoxRecipeName.Text)
            && (ComboBoxCategoryName.SelectedValue == null || string.IsNullOrEmpty(ComboBoxCategoryName.SelectedValue.ToString()))
            && (ComboBoxKitchenName.SelectedValue == null || string.IsNullOrEmpty(ComboBoxKitchenName.SelectedValue.ToString()))
            && (ComboBoxMajorIngredientName.SelectedValue == null || string.IsNullOrEmpty(ComboBoxMajorIngredientName.SelectedValue.ToString()))
            && (ComboBoxTypeCookingName.SelectedValue == null || string.IsNullOrEmpty(ComboBoxTypeCookingName.SelectedValue.ToString()))
            && (ComboBoxTypeFood.SelectedValue == null || string.IsNullOrEmpty(ComboBoxTypeFood.SelectedValue.ToString())))
        {
            MessageBox.Show("Хотя бы одно из полей должно быть заполнено!");
        }
        else
        {

            var recipes = db.Recipes.AsQueryable();

        if (!string.IsNullOrEmpty(TextBoxRecipeName.Text))
            recipes = recipes.Where(r => r.NameRecipe.ToLower().Contains(TextBoxRecipeName.Text.Trim().ToLower()));

        if (ComboBoxCategoryName.SelectedValue != null)
        {
            var selectedCategory = ComboBoxCategoryName.SelectedValue.ToString();
            recipes = recipes.Where(r => r.Category.Name == selectedCategory);
        }

        if (ComboBoxKitchenName.SelectedValue != null)
        {
            var selectedKitchen = ComboBoxKitchenName.SelectedValue.ToString();
            recipes = recipes.Where(r => r.Kitchen.Name == selectedKitchen);
        }

        if (ComboBoxMajorIngredientName.SelectedValue != null)
        {
            var selectedIngredient = ComboBoxMajorIngredientName.SelectedValue.ToString();
            recipes = recipes.Where(r => r.Ingredients.Contains(selectedIngredient));
        }

        if (ComboBoxTypeCookingName.SelectedValue != null)
        {
            var selectedTypeCooking = ComboBoxTypeCookingName.SelectedValue.ToString();
            recipes = recipes.Where(r => r.TypeOfCooking.Name == selectedTypeCooking);
        }

        if (ComboBoxTypeFood.SelectedValue != null)
        {
            var selectedTypeFood = ComboBoxTypeFood.SelectedValue.ToString();
            recipes = recipes.Where(r => r.TypeOfDish.Name == selectedTypeFood);
        }

        var filteredRecipes = recipes.ToList();

        var recipes2 = new Recipes2();

        recipes2.SearchBigResult(filteredRecipes);
        recipes2.Show();
        Close();
        }
    }


    private void Recipes_OnLoaded(object sender, RoutedEventArgs e)
    {
        db.Categories.Load();
        db.Kitchens.Load();
        db.MainProducts.Load();
        db.TypeOfCookings.Load();
        db.TypeOfDishes.Load();

        ComboBoxCategoryName.ItemsSource = db.Categories.Local.Select(c => c.Name).ToList();
        ComboBoxKitchenName.ItemsSource = db.Kitchens.Local.Select(k => k.Name).ToList();
        ComboBoxMajorIngredientName.ItemsSource = db.MainProducts.Local.Select(mp => mp.Name).ToList();
        ComboBoxTypeCookingName.ItemsSource = db.TypeOfCookings.Local.Select(tc => tc.Name).ToList();
        ComboBoxTypeFood.ItemsSource = db.TypeOfDishes.Local.Select(td => td.Name).ToList();
    }
}