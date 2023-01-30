using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using EbookStore.Presentation.RefitClient;
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

namespace EbookStore.Presentation.View.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly IUserClient _userClient;
        public UserLoginRequest LoginRequest { get; set; }

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Login_Button.IsEnabled = false;
                var request = new UserLoginRequest()
                {
                    UserName = string.Empty,
                    Password = string.Empty
                };
                request.Password = Password_Passwordbox.Password.Trim();
                string token = await _userClient.LoginAsync(LoginRequest);
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
