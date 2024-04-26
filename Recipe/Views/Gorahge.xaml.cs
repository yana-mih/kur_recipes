using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Recipe.Models;
using Recipe.Models.Helper;
using Recipe.VM;

namespace Recipe.Views;

/// <summary>
///     Логика взаимодействия для Gorahge.xaml
/// </summary>
public partial class Gorahge : Window
{
    private readonly HotVM Vm = new();
    private RecipeContext db = new();

    public Gorahge()
    {
        InitializeComponent();
        DataContext = Vm;
    }

    private void SearchBox_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            if (!string.IsNullOrEmpty(SearchBox.Text))
            {
                var recipes = new Recipes2();
                recipes.Show();
                recipes.SearchResult(SearchBox.Text.Trim().ToLower());
                Close();
            }
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

    private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        var stackPanel = sender as StackPanel;
        if (stackPanel != null)
        {
            var selectedRecipe = stackPanel.DataContext as RecipeHelper;
            if (selectedRecipe != null)
            {
                var selectedRecipeWindow = new SelectedRecipe(selectedRecipe);
                selectedRecipeWindow.Show();
                Close();
            }
        }
    }
}