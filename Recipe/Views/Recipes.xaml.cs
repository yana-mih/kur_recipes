using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Recipe.Models;

namespace Recipe.Views
{
    /// <summary>
    /// Логика взаимодействия для Recipes.xaml
    /// </summary>
    public partial class Recipes : Window
    {
        private RecipeContext db = new RecipeContext();
        public Recipes()
        {
            InitializeComponent();
        }

        private void ButtonZakuski_OnClick(object sender, RoutedEventArgs e)
        {
            Zakuski zakuski = new Zakuski();
            zakuski.Show();
            this.Close();
        }

        private void ButtonSalads_OnClick(object sender, RoutedEventArgs e)
        {
            Salat salat = new Salat();
            salat.Show();
            this.Close();
        }

        private void ButtonHot_OnClick(object sender, RoutedEventArgs e)
        {
            Gorahge gorahge = new Gorahge();
            gorahge.Show();
            this.Close();
        }

        private void ButtonSoups_OnClick(object sender, RoutedEventArgs e)
        {
            Sup sup = new Sup();
            sup.Show();
            this.Close();
        }

        private void ButtonVipechka_OnClick(object sender, RoutedEventArgs e)
        {
            Vipechka vipechka = new Vipechka();
            vipechka.Show();
            this.Close();
        }

        private void ButtonDeserts_OnClick(object sender, RoutedEventArgs e)
        {
            Desert deserts = new Desert();
            deserts.Show();
            this.Close();
        }

        private void ButtonSouses_OnClick(object sender, RoutedEventArgs e)
        {
            Souse us = new Souse();
            us.Show();
            this.Close();
        }

        private void ButtonToProfile_OnClick(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser != null)
            {
                Profile2 profile = new Profile2();
                profile.Show();
                this.Close();
            }
            else
            {
                Profile profile = new Profile();
                profile.Show();
                this.Close();
            }
        }

        private void ButtonToRecipes_OnClick(object sender, RoutedEventArgs e)
        {
            Recipes recipes = new Recipes();
            recipes.Show();
            this.Close();
        }

        private void ButtonToGeneral_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonAddNewRecipe_OnClick(object sender, RoutedEventArgs e)
        {
            Dobavlenie dobavlenie = new Dobavlenie();
            dobavlenie.Show();
            this.Close();
        }

        private void ButtonSearch_OnClick(object sender, RoutedEventArgs e)
        {
            var recipes = db.Recipes.AsQueryable();

            if (!string.IsNullOrEmpty(TextBoxRecipeName.Text))
            {
                recipes = recipes.Where(r => r.NameRecipe.ToLower().Contains(TextBoxRecipeName.Text.Trim().ToLower()));
            }

            if (ComboBoxCategoryName.SelectedValue != null)
            {
                string selectedCategory = ComboBoxCategoryName.SelectedValue.ToString();
                recipes = recipes.Where(r => r.Category.Name == selectedCategory);
            }

            if (ComboBoxKitchenName.SelectedValue != null)
            {
                string selectedKitchen = ComboBoxKitchenName.SelectedValue.ToString();
                recipes = recipes.Where(r => r.Kitchen.Name == selectedKitchen);
            }

            if (ComboBoxMajorIngredientName.SelectedValue != null)
            {
                string selectedIngredient = ComboBoxMajorIngredientName.SelectedValue.ToString();
                recipes = recipes.Where(r => r.Ingredients.Contains(selectedIngredient));
            }

            if (ComboBoxTypeCookingName.SelectedValue != null)
            {
                string selectedTypeCooking = ComboBoxTypeCookingName.SelectedValue.ToString();
                recipes = recipes.Where(r => r.TypeOfCooking.Name == selectedTypeCooking);
            }

            if (ComboBoxTypeFood.SelectedValue != null)
            {
                string selectedTypeFood = ComboBoxTypeFood.SelectedValue.ToString();
                recipes = recipes.Where(r => r.TypeOfDish.Name == selectedTypeFood);
            }

            var filteredRecipes = recipes.ToList();

            Recipes2 recipes2 = new Recipes2();

            recipes2.SearchBigResult(filteredRecipes);
            recipes2.Show();
            this.Close();
            
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
}
