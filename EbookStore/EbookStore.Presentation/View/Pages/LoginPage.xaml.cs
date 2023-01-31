using DIInWPF.StartupHelpers;
using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using EbookStore.Presentation.RefitClient;
using System.Windows;
using System.Windows.Controls;

namespace EbookStore.Presentation.View.Pages;

public partial class LoginPage : Page
{
    private readonly IUserClient _userClient;
    private readonly MainWindow _mainWindow; 

    public UserLoginRequest LoginRequest { get; set; }

    public LoginPage(IUserClient userClient)
    {
        InitializeComponent();
        _userClient = userClient;
        _mainWindow = Application.Current.MainWindow as MainWindow;
    }

    private async void Login_Button_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Login_Button.IsEnabled = false;
            var request = new UserLoginRequest()
            {
                UserName = Username_TextBox.Text,
                Password = Password_Passwordbox.Password
            };
            request.Password = Password_Passwordbox.Password.Trim();
            string token = await _userClient.AuthenticateAsync(request);
        }
        catch
        {
            ShowErrorMessage();
        }
        finally
        {
            Login_Button.IsEnabled = true;
        }
    }

    private void ShowErrorMessage()
    {

    }

    private void ToRegisterPage_Button_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.FrMain.Content = _mainWindow.GetRegisterPage();
    }
}
