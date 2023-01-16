using EbookStore.Presentation.Validator;
using EbookStore.Presentation.Validator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using static EbookStore.Presentation.Validator.TextInputWithGroupBoxValidator;

namespace EbookStore.Presentation.View.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateUser())
            {
                Trace.WriteLine("valid");
            }
            else
            {
                Trace.WriteLine("Invalid");
            }
        }

        private bool ValidateUser()
        {
            IErrorable registerError = new RegisterError
            {
                UsernameValidity = Username_TextBox.ValidateValidStringLength(4, 20),
                FirstNameValidity = FirstName_TextBox.ValidateHasInput(),
                LastNameValidity = LastName_TextBox.ValidateHasInput(),
                PasswordValidity = Password_TextBox.ValidateValidStringLength(6, 100),
                ConfirmPasswordValidity = 
                    ConfirmPassword_TextBox.ValidateMatchTextBox(Password_TextBox, "Password"),
                EmailValidity = 
                    Email_TextBox.ValidateMatchPattern(RegexPattern.EmailAddress, "Email Address"),
                PhoneNumberValidity = 
                    PhoneNumber_TextBox.ValidateMatchPattern(RegexPattern.PhoneNumber, "Phone number")
            };

            return registerError.IsValid();
        }
    }
}
