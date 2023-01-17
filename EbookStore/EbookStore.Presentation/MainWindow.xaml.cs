using DIInWPF.StartupHelpers;
using EbookStore.Presentation.RefitClient;
using EbookStore.Presentation.View.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EbookStore.Presentation;

public partial class MainWindow : Window
{
    private readonly Page _registerPage;

    public MainWindow(IAbstractFactory<RegisterPage> registerFactory)
    {
        InitializeComponent();
        _registerPage = registerFactory.Create();
        frMain.Content = _registerPage;
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
