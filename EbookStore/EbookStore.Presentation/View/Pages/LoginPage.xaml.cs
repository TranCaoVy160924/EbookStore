using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using EbookStore.Presentation.RefitClient;
using System.Windows;
using System.Windows.Controls;

namespace EbookStore.Presentation.View.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly IUserClient _userClient;
        public UserLoginRequest LoginRequest { get; set; }

        public LoginPage(IUserClient userClient)
        {
            InitializeComponent();
            _userClient = userClient;
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
    }
}
