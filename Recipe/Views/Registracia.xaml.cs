using System.Windows;
using Recipe.Models;

namespace Recipe.Views;

/// <summary>
///     Логика взаимодействия для Registracia.xaml
/// </summary>
public partial class Registracia : Window
{
    private readonly RecipeContext db = new();

    public Registracia()
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

    private void ButtonReg_OnClick(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(BoxLogin.Text) &&
            !string.IsNullOrEmpty(BoxPassword.Password) &&
            !string.IsNullOrEmpty(PickerDate.Text) &&
            !string.IsNullOrEmpty(BoxLastName.Text) &&
            !string.IsNullOrEmpty(BoxName.Text))
        {
            var selectedDateNullable = PickerDate.SelectedDate;

            if (selectedDateNullable.HasValue)
            {
                var selectedDate = selectedDateNullable.Value;

                if (selectedDate != null)
                {
                    var currentDate = DateTime.Today;
                    var age = currentDate.Year - selectedDate.Year;

                    if (currentDate.Month < selectedDate.Month ||
                        (currentDate.Month == selectedDate.Month && currentDate.Day < selectedDate.Day))
                        age--;

                    if (age < 12) MessageBox.Show("Ваш возраст не может быть меньше 12 лет!");
                }

                if (BoxLogin.Text.Length <= 4)
                    MessageBox.Show("Длина логина должна превышать 4 символа!");
                else if (BoxPassword.Password.Length <= 4)
                    MessageBox.Show("Длина пароля должна превышать 4 символа!");
                else if (BoxLastName.Text.Length <= 3)
                    MessageBox.Show("Длина фамилии должна превышать 3 символа!");
                else if (BoxName.Text.Length <= 1) MessageBox.Show("Длина имени должна превышать 1 символ!");
            }
            else
            {
                var existPerson = db.People
                    .Where(p => p.Login == BoxLogin.Text).FirstOrDefault();

                if (existPerson != null)
                {
                    MessageBox.Show("Ошибка! Логин уже занят");
                }
                else
                {
                    var person = new Person
                    {
                        FirstName = BoxName.Text,
                        LastName = BoxLastName.Text,
                        Birthday = DateTime.Parse(PickerDate.Text),
                        Login = BoxLogin.Text,
                        Password = BoxPassword.Password
                    };
                    db.People.Add(person);
                    db.SaveChanges();

                    App.CurrentUser = person;
                    var profile2 = new Profile2();
                    profile2.Show();
                    Close();
                }
            }
        }
        else
        {
            MessageBox.Show("Не все поля заполнены!");
        }
    }
}