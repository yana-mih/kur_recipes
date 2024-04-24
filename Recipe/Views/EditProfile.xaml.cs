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
    /// Логика взаимодействия для EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Window
    {
        public EditProfile()
        {
            InitializeComponent();
        }

        private RecipeContext db = new RecipeContext();

        private void Profile2_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextBlockCurrentUserBDate.Text = App.CurrentUser.Birthday.ToLongDateString();
            TextBlockCurrentUserLname.Text = App.CurrentUser.LastName.ToString();
            TextBlockCurrentUsername.Text = App.CurrentUser.FirstName.ToString();
        }

        public event EventHandler DataUpdated;
        private void ButtonSaveChanges_OnClick(object sender, RoutedEventArgs e)
        {
            App.CurrentUser.FirstName = TextBlockCurrentUsername.Text;
            App.CurrentUser.LastName = TextBlockCurrentUserLname.Text;
            App.CurrentUser.Birthday = DateTime.Parse(TextBlockCurrentUserBDate.Text);

            var saveuser = db.People.Where(p => p.PersonId == App.CurrentUser.PersonId).FirstOrDefault();
            saveuser.FirstName = App.CurrentUser.FirstName;
            saveuser.LastName = App.CurrentUser.LastName;
            saveuser.Birthday = App.CurrentUser.Birthday;

            db.SaveChanges();

            DataUpdated?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
