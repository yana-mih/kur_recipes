using Microsoft.Win32;
using System.Windows;
using Recipe.Helper;
using Recipe.Models;
using Microsoft.EntityFrameworkCore;

namespace Recipe.Views
{
    public partial class Dobavlenie : Window
    {
        private RecipeContext db = new RecipeContext();
        private Image selectedImage;
        public Dobavlenie()
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog.FileName;
                BoxAddPhoto.Visibility = Visibility.Visible;
                ButtonAddPhoto.Visibility = Visibility.Hidden;

                Image image = new Image()
                {
                    Image1 = ImgHelper.ImageToByteArray(selectedFileName)
                };

                selectedImage = image;
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser != null)
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

                        string name = BoxNameRecipe.Text;
                        string descryption = BoxDescryption.Text;
                        string ingredients = BoxIngredients.Text;
                        string kbzy = BoxKBZY.Text;
                        string time = BoxTime.Text;

                        MainProduct mainProduct1 =
                            db.MainProducts.FirstOrDefault(m => m.Name == mainProduct);

                        MainProductRecipe mainprodrRecipe1 = db.MainProductRecipes
                            .FirstOrDefault(mp => mp.MainProductId == mainProduct1.MainProductId);

                        Kitchen kitchen1 = db.Kitchens.FirstOrDefault(k => k.Name == kitchen);

                        TypeOfCooking typeOfCooking1 =
                            db.TypeOfCookings.FirstOrDefault(k => k.Name == typeOfCooking);

                        TypeOfDish typeOfDish1 = db.TypeOfDishes.FirstOrDefault(k => k.Name == typeOfDish);

                        Category category1 = db.Categories.FirstOrDefault(c => c.Name == category);

                        db.Images.Add(selectedImage);
                        db.SaveChanges();

                        var savedimage = db.Images.FirstOrDefault(i => i.ImageId == selectedImage.ImageId);

                        Models.Recipe newRecipe = new Models.Recipe()
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

                        MainProductRecipe mainProductRecipe = new MainProductRecipe()
                        {
                            RecipeId = newRecipe.RecipeId,
                            MainProductId = mainProduct1.MainProductId
                        };

                        db.MainProductRecipes.Add(mainProductRecipe);
                        db.SaveChanges();

                        MessageBox.Show("Рецепт успешно добавлен!");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
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
            else
            {
                MessageBox.Show("Для добавления рецепта нужно войти в профиль!");
            }
        }
    }
}
