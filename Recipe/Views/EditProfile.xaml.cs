using System.Windows;
using Recipe.Models;

namespace Recipe.Views;

/// <summary>
///     Логика взаимодействия для EditProfile.xaml
/// </summary>
public partial class EditProfile : Window
{
    private readonly RecipeContext db = new();

    public EditProfile()
    {
        InitializeComponent();
    }

    private void Profile2_OnLoaded(object sender, RoutedEventArgs e)
    {
        TextBlockCurrentUserBDate.Text = App.CurrentUser.Birthday.ToLongDateString();
        TextBlockCurrentUserLname.Text = App.CurrentUser.LastName;
        TextBlockCurrentUsername.Text = App.CurrentUser.FirstName;
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
        Close();
    }
}