using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Recipe.Views;

namespace TestProject1;

public class UnitTest1
{
    [WpfFact]
    public void TestButtonDeserts_OnClick()
    {
        var mainWindow = new MainWindow();
        mainWindow.InitializeComponent();

        var outerGrid = mainWindow.FindName("outerGrid") as Grid;

        if (outerGrid != null)
        {
            var innerGrid = outerGrid.FindName("currentGrid") as Grid;

            if (innerGrid != null)
            {
                var button = mainWindow.FindName("ButtonDeserts") as Button;

                Assert.NotNull(button);

                if (button != null)
                {
                    var eventArgs = new RoutedEventArgs(ButtonBase.ClickEvent);

                    button.RaiseEvent(eventArgs);

                    Assert.Single(Application.Current.Windows);
                    Assert.IsType<Desert>(Application.Current.Windows[0]);
                }
            }
        }
    }

    [WpfFact]
    public void TestButtonSalads_OnClick()
    {
        var mainWindow = new MainWindow();
        mainWindow.InitializeComponent();

        var outerGrid = mainWindow.FindName("outerGrid") as Grid;

        if (outerGrid != null)
        {
            var innerGrid = outerGrid.FindName("currentGrid") as Grid;

            if (innerGrid != null)
            {
                var button = mainWindow.FindName("ButtonSalads") as Button;

                Assert.NotNull(button);

                if (button != null)
                {
                    var eventArgs = new RoutedEventArgs(ButtonBase.ClickEvent);

                    button.RaiseEvent(eventArgs);

                    Assert.Single(Application.Current.Windows);
                    Assert.IsType<Salat>(Application.Current.Windows[0]);
                }
            }
        }
    }

    [WpfFact]
    public void TestButtonZakuski_OnClick()
    {
        var mainWindow = new MainWindow();
        mainWindow.InitializeComponent();

        var outerGrid = mainWindow.FindName("outerGrid") as Grid;

        if (outerGrid != null)
        {
            var innerGrid = outerGrid.FindName("currentGrid") as Grid;

            if (innerGrid != null)
            {
                var button = mainWindow.FindName("ButtonZakuski") as Button;

                Assert.NotNull(button);

                if (button != null)
                {
                    var eventArgs = new RoutedEventArgs(ButtonBase.ClickEvent);

                    button.RaiseEvent(eventArgs);

                    Assert.Single(Application.Current.Windows);
                    Assert.IsType<Zakuski>(Application.Current.Windows[0]);
                }
            }
        }
    }

    [WpfFact]
    public void TestButtonSup_OnClick()
    {
        var mainWindow = new MainWindow();
        mainWindow.InitializeComponent();

        var outerGrid = mainWindow.FindName("outerGrid") as Grid;

        if (outerGrid != null)
        {
            var innerGrid = outerGrid.FindName("currentGrid") as Grid;

            if (innerGrid != null)
            {
                var button = mainWindow.FindName("ButtonSoups") as Button;

                Assert.NotNull(button);

                if (button != null)
                {
                    var eventArgs = new RoutedEventArgs(ButtonBase.ClickEvent);

                    button.RaiseEvent(eventArgs);

                    Assert.Single(Application.Current.Windows);
                    Assert.IsType<Sup>(Application.Current.Windows[0]);
                }
            }
        }
    }

    [WpfFact]
    public void TestButtonSouses_OnClick()
    {
        var mainWindow = new MainWindow();
        mainWindow.InitializeComponent();

        var outerGrid = mainWindow.FindName("outerGrid") as Grid;

        if (outerGrid != null)
        {
            var innerGrid = outerGrid.FindName("currentGrid") as Grid;

            if (innerGrid != null)
            {
                var button = mainWindow.FindName("ButtonSouses") as Button;

                Assert.NotNull(button);

                if (button != null)
                {
                    var eventArgs = new RoutedEventArgs(ButtonBase.ClickEvent);

                    button.RaiseEvent(eventArgs);

                    Assert.Single(Application.Current.Windows);
                    Assert.IsType<Souse>(Application.Current.Windows[0]);
                }
            }
        }
    }

    [WpfFact]
    public void TestButtonVipechka_OnClick()
    {
        var mainWindow = new MainWindow();
        mainWindow.InitializeComponent();

        var outerGrid = mainWindow.FindName("outerGrid") as Grid;

        if (outerGrid != null)
        {
            var innerGrid = outerGrid.FindName("currentGrid") as Grid;

            if (innerGrid != null)
            {
                var button = mainWindow.FindName("ButtonVipechka") as Button;

                Assert.NotNull(button);

                if (button != null)
                {
                    var eventArgs = new RoutedEventArgs(ButtonBase.ClickEvent);

                    button.RaiseEvent(eventArgs);

                    Assert.Single(Application.Current.Windows);
                    Assert.IsType<Vipechka>(Application.Current.Windows[0]);
                }
            }
        }
    }

    [WpfFact]
    public void TestButtonHot_OnClick()
    {
        var mainWindow = new MainWindow();
        mainWindow.InitializeComponent();

        var outerGrid = mainWindow.FindName("outerGrid") as Grid;

        if (outerGrid != null)
        {
            var innerGrid = outerGrid.FindName("currentGrid") as Grid;

            if (innerGrid != null)
            {
                var button = mainWindow.FindName("ButtonHot") as Button;

                Assert.NotNull(button);

                if (button != null)
                {
                    var eventArgs = new RoutedEventArgs(ButtonBase.ClickEvent);

                    button.RaiseEvent(eventArgs);

                    Assert.Single(Application.Current.Windows);
                    Assert.IsType<Gorahge>(Application.Current.Windows[0]);
                }
            }
        }
    }
}