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
using Recipe.Models;

namespace Recipe.Views
{
    /// <summary>
    /// Логика взаимодействия для Registracia.xaml
    /// </summary>
    public partial class Registracia : Window
    {
        private RecipeContext db = new RecipeContext();
        public Registracia()
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

        private void ButtonReg_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(BoxLogin.Text) &&
                !string.IsNullOrEmpty(BoxPassword.Password.ToString()) &&
                !string.IsNullOrEmpty(PickerDate.Text) &&
                !string.IsNullOrEmpty(BoxLastName.Text) &&
                !string.IsNullOrEmpty(BoxName.Text))
            {
                Person? existPerson = db.People
                    .Where(p => p.Login == BoxLogin.Text && p.Password == p.Password).FirstOrDefault();

                if (existPerson != null)
                {
                    MessageBox.Show("Ошибка!");
                }
                else
                {
                    Person person = new Person()
                {
                    FirstName = BoxName.Text,
                    LastName = BoxLastName.Text,
                    Birthday = DateTime.Parse(PickerDate.Text),
                    Login = BoxLogin.Text,
                    Password = BoxPassword.Password.ToString()
                };
                    db.People.Add(person);
                    db.SaveChanges();

                    App.CurrentUser = person;
                    Profile2 profile2 = new Profile2();
                    profile2.Show();
                    this.Close();
                }

                
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }
    }
}
