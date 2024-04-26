using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Recipe.Helper;
using Recipe.Models;

namespace Recipe.Views;

public partial class Dobavlenie : Window
{
    private readonly RecipeContext db = new();
    private Image selectedImage;

    public Dobavlenie()
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

    private void Dobavlenie_OnLoaded(object sender, RoutedEventArgs e)
    {
        db.Categories.Load();
        db.Kitchens.Load();
        db.MainProducts.Load();
        db.TypeOfCookings.Load();
        db.TypeOfDishes.Load();

        BoxCategory.ItemsSource = db.Categories.Local.Select(c => c.Name).ToList();
        BoxKithen.ItemsSource = db.Kitchens.Local.Select(k => k.Name).ToList();
        BoxMajorIngr.ItemsSource = db.MainProducts.Local.Select(mp => mp.Name).ToList();
        BoxPreparationType.ItemsSource = db.TypeOfCookings.Local.Select(tc => tc.Name).ToList();
        BoxTypeDish.ItemsSource = db.TypeOfDishes.Local.Select(td => td.Name).ToList();
    }

    private void ButtonAddPhoto_OnClick(object sender, RoutedEventArgs e)
    {
        GetImage();
    }

    private void GetImage()
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            var selectedFileName = openFileDialog.FileName;
            BoxAddPhoto.Visibility = Visibility.Visible;
            ButtonAddPhoto.Visibility = Visibility.Hidden;

            var image = new Image
            {
                Image1 = ImgHelper.ImageToByteArray(selectedFileName)
            };

            selectedImage = image;
        }
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (selectedImage != null)
        {
            if (!string.IsNullOrEmpty(BoxTypeDish.SelectedValue?.ToString())
                && !string.IsNullOrEmpty(BoxCategory.SelectedValue?.ToString())
                && !string.IsNullOrEmpty(BoxMajorIngr.SelectedValue?.ToString())
                && !string.IsNullOrEmpty(BoxKithen.SelectedValue?.ToString())
                && !string.IsNullOrEmpty(BoxPreparationType.SelectedValue?.ToString())
                && !string.IsNullOrEmpty(BoxNameRecipe.Text)
                && !string.IsNullOrEmpty(BoxDescryption.Text)
                && !string.IsNullOrEmpty(BoxIngredients.Text)
                && !string.IsNullOrEmpty(BoxKBZY.Text)
                && !string.IsNullOrEmpty(BoxTime.Text))
            {
                var typeOfDish = BoxTypeDish.SelectedValue.ToString();
                var category = BoxCategory.SelectedValue.ToString();
                var mainProduct = BoxMajorIngr.SelectedValue.ToString();
                var kitchen = BoxKithen.SelectedValue.ToString();
                var typeOfCooking = BoxPreparationType.SelectedValue.ToString();

                var name = BoxNameRecipe.Text;
                var descryption = BoxDescryption.Text;
                var ingredients = BoxIngredients.Text;
                var kbzy = BoxKBZY.Text;
                var time = BoxTime.Text;

                var mainProduct1 =
                    db.MainProducts.FirstOrDefault(m => m.Name == mainProduct);

                var mainprodrRecipe1 = db.MainProductRecipes
                    .FirstOrDefault(mp => mp.MainProductId == mainProduct1.MainProductId);

                var kitchen1 = db.Kitchens.FirstOrDefault(k => k.Name == kitchen);

                var typeOfCooking1 =
                    db.TypeOfCookings.FirstOrDefault(k => k.Name == typeOfCooking);

                var typeOfDish1 = db.TypeOfDishes.FirstOrDefault(k => k.Name == typeOfDish);

                var category1 = db.Categories.FirstOrDefault(c => c.Name == category);

                db.Images.Add(selectedImage);
                db.SaveChanges();

                var savedimage = db.Images.FirstOrDefault(i => i.ImageId == selectedImage.ImageId);

                var newRecipe = new Models.Recipe
                {
                    Description = descryption,
                    NameRecipe = name,
                    Ingredients = ingredients,
                    CategoryId = category1.CategoryId,
                    KitchenId = kitchen1.KitchenId,
                    TypeOfCookingId = typeOfCooking1.TypeOfCookingId,
                    TypeOfDishId = typeOfDish1.TypeOfDish1,
                    PersonId = App.CurrentUser.PersonId,
                    ImageId = savedimage.ImageId,
                    Kbzy = kbzy,
                    Time = time
                };

                db.Recipes.Add(newRecipe);
                db.SaveChanges();

                var mainProductRecipe = new MainProductRecipe
                {
                    RecipeId = newRecipe.RecipeId,
                    MainProductId = mainProduct1.MainProductId
                };

                db.MainProductRecipes.Add(mainProductRecipe);
                db.SaveChanges();

                MessageBox.Show("Рецепт успешно добавлен!");
                var mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
        }
        else
        {
            MessageBox.Show("Выберите изображение!");
        }
    }
}