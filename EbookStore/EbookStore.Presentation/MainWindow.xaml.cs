using DIInWPF.StartupHelpers;
using EbookStore.Presentation.RefitClient;
using EbookStore.Presentation.View.Pages;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EbookStore.Presentation;

public partial class MainWindow : Window
{
    [DllImport("Kernel32")]
    public static extern void AllocConsole();

    [DllImport("Kernel32")]
    public static extern void FreeConsole();

    private readonly IAbstractFactory<RegisterPage> _registerFactory;
    private readonly IAbstractFactory<LoginPage> _loginFactory;
    private readonly IAbstractFactory<HomePage> _homeFactory;
    private readonly IAbstractFactory<BookCreatePage> _bookCreateFactory;
    private readonly IAbstractFactory<BookUpdatePage> _bookUpdateFactory;

    public string JwtToken { get; set; }
    public string OriginalToken { get; set; }

    public MainWindow(
        IAbstractFactory<RegisterPage> registerFactory,
        IAbstractFactory<LoginPage> loginFactory,
        IAbstractFactory<HomePage> homeFactory,
        IAbstractFactory<BookCreatePage> bookCreateFactory,
        IAbstractFactory<BookUpdatePage> bookUpdateFactory)
    {
        AllocConsole();
        InitializeComponent();
        _registerFactory = registerFactory;
        _loginFactory = loginFactory;
        _homeFactory = homeFactory;
        _bookCreateFactory = bookCreateFactory;
        _bookUpdateFactory = bookUpdateFactory;
        ToLoginPage();
    }

    public void ToRegisterPage()
    {
        frMain.Content = _registerFactory.Create();
    }

    public void ToLoginPage()
    {
        frMain.Content = _loginFactory.Create();
    }

    public void ToHomePage()
    {
        frMain.Content = _homeFactory.Create();
    }

    public void ToBookCreatePage()
    {
        frMain.Content = _bookCreateFactory.Create();
    }

    public async Task ToBookUpdatePage(int id)
    {
        BookUpdatePage bookUpdatePage = _bookUpdateFactory.Create();
        await bookUpdatePage.SetOriginalBook(id);
        frMain.Content = bookUpdatePage;
    }


    private void Minimize_Button_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void Cancel_Button_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }
}
