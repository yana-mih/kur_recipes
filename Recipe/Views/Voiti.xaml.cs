using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Recipe.Models;

namespace Recipe.Views;

public partial class Voiti : Window
{
    private readonly RecipeContext db = new();
    public TextBox TextBoxLogin { get; set; }

    public PasswordBox TextBoxPassword { get; set; }
    public Voiti()
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

    public void ButtonSignIn_OnClick(object sender, RoutedEventArgs e)
    {
        TextBoxLogin = TextBoxUserLogin;
        TextBoxPassword = FindName("TextBoxUserPassword") as PasswordBox;

        if (!string.IsNullOrEmpty(TextBoxLogin.Text) &&
            !string.IsNullOrEmpty(TextBoxPassword.Password))
        {
            if (TextBoxLogin.Text.Length <= 4)
            {
                MessageBox.Show("Длина логина должна превышать 4 символа!");
            }
            else if (TextBoxPassword.Password.Length <= 4)
            {
                MessageBox.Show("Длина пароля должна превышать 4 символа!");
            }
            else
            {
                var currUser = db.People.Where(p => p.Password == TextBoxPassword.Password.Trim()
                                                    && p.Login == TextBoxLogin.Text.Trim()).FirstOrDefault();
                if (currUser != null)
                {
                    App.CurrentUser = currUser;
                    Profile2 profile = new();
                    profile.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Логин или пароль введен неверно!");
                }
            }
        }
        else
        {
            MessageBox.Show("Все поля должны быть заполнены!");
        }
        
    }
}