using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Recipe.Models;
using Recipe.Models.Helper;
using Recipe.VM;

namespace Recipe.Views
{
    /// <summary>
    /// Логика взаимодействия для Recipes2.xaml
    /// </summary>
    public partial class Recipes2 : Window
    {
        private RecipeContext db = new RecipeContext();
        private BaseRecipeVM vm = new BaseRecipeVM();
        public Recipes2()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel stackPanel = sender as StackPanel;
            if (stackPanel != null)
            {
                RecipeHelper selectedRecipe = stackPanel.DataContext as RecipeHelper;
                if (selectedRecipe != null)
                {
                    SelectedRecipe selectedRecipeWindow = new SelectedRecipe(selectedRecipe);
                    selectedRecipeWindow.Show();
                    this.Close();
                }
            }
        }

        private void SearchBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(SearchBox.Text))
                {
                    Recipes2 recipes = new Recipes2();
                    recipes.Show();
                    recipes.SearchResult(SearchBox.Text.Trim().ToLower());
                    this.Close();
                }
            }
        }

        public void SearchResult(string recipename)
        {
            CategoryControl.ItemsSource = vm.GetSearhResult(recipename);
        }

        public void SearchBigResult(List<Models.Recipe> listRecipes)
        {
            CategoryControl.ItemsSource = vm.GetBigSearchResult(listRecipes);
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
    }
}
