using DIInWPF.StartupHelpers;
using EbookStore.Presentation.RefitClient;
using EbookStore.Presentation.View.Pages;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EbookStore.Presentation;

public partial class MainWindow : Window
{
    private readonly IAbstractFactory<RegisterPage> _registerFactory;
    private readonly IAbstractFactory<LoginPage> _loginFactory;

    public Frame FrMain { get; set; }

    public MainWindow(
        IAbstractFactory<RegisterPage> registerFactory,
        IAbstractFactory<LoginPage> loginFactory)
    {
        InitializeComponent();
        _registerFactory = registerFactory;
        _loginFactory = loginFactory;
        FrMain = frMain;
        FrMain.Content = GetLoginPage();
    }

    public RegisterPage GetRegisterPage() => _registerFactory.Create();

    public LoginPage GetLoginPage() => _loginFactory.Create();


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
