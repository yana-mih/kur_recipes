﻿using System.Windows;

namespace Recipe.Views;

public partial class Profile2 : Window
{
    public Profile2()
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

    private void Profile2_OnLoaded(object sender, RoutedEventArgs e)
    {
        TextBlockCurrentUserBDate.Text = App.CurrentUser.Birthday.ToString();
        TextBlockCurrentUserLname.Text = App.CurrentUser.LastName;
        TextBlockCurrentUsername.Text = App.CurrentUser.FirstName;
    }


    private void ButtonToChanged_OnClick(object sender, RoutedEventArgs e)
    {
        var editProfile = new EditProfile();
        editProfile.DataUpdated += (s, args) =>
        {
            TextBlockCurrentUserBDate.Text = App.CurrentUser.Birthday.ToString();
            TextBlockCurrentUserLname.Text = App.CurrentUser.LastName;
            TextBlockCurrentUsername.Text = App.CurrentUser.FirstName;
        };
        editProfile.ShowDialog();
    }
}