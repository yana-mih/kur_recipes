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
using Recipe.Helper;
using Recipe.Models;
using Recipe.Models.Helper;

namespace Recipe.Views
{
    /// <summary>
    /// Логика взаимодействия для SelectedRecipe.xaml
    /// </summary>
    public partial class SelectedRecipe : Window
    {
        private RecipeContext db = new RecipeContext();
        public SelectedRecipe(RecipeHelper currPecipe)
        {
            InitializeComponent();

            MainProductRecipe mainprod1 = db.MainProductRecipes.Where(mp => mp.MainProductRecipeId == currPecipe.RecipeId).FirstOrDefault();

            MainProduct mainProduct =
                db.MainProducts.Where(m => m.MainProductId == mainprod1.MainProductId).FirstOrDefault();

            Person person = db.People.Where(p => p.PersonId == currPecipe.PersonId).FirstOrDefault();

            Kitchen kitchen = db.Kitchens.Where(k => k.KitchenId == currPecipe.KitchenId).FirstOrDefault();

            TypeOfCooking typeOfCooking = db.TypeOfCookings.Where(k => k.TypeOfCookingId == currPecipe.TypeOfCookingId).FirstOrDefault();

            TypeOfDish typeOfDish = db.TypeOfDishes.Where(k => k.TypeOfDish1 == currPecipe.TypeOfDishId).FirstOrDefault();


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
    }
}
