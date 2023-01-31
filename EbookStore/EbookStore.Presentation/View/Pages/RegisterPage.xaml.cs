using DIInWPF.StartupHelpers;
using EbookStore.Contract.ViewModel.User.UserRegisterResponse;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using EbookStore.Presentation.RefitClient;
using EbookStore.Presentation.Validator;
using EbookStore.Presentation.Validator.Models;
using EbookStore.Presentation.ViewModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using static EbookStore.Presentation.Validator.TextInputWithGroupBoxValidator;
using static EbookStore.Presentation.Validator.PasswordWithGroupBoxValidator;
using System;

namespace EbookStore.Presentation.View.Pages;

public partial class RegisterPage : Page
{
    private readonly UserRegisterViewModel _registerViewModel;
    private readonly MainWindow _mainWindow;


    public RegisterPage(
        IAbstractFactory<UserRegisterViewModel> registerViewModelFactory)
    {
        InitializeComponent();

        _registerViewModel = registerViewModelFactory.Create();
        _mainWindow = Application.Current.MainWindow as MainWindow;

        this.DataContext = _registerViewModel.RegisterRequest;
    }

    private async void Register_Button_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Register_Button.IsEnabled = false;
            if (ValidateUser())
            {
                var request = _registerViewModel.RegisterRequest;
                request.Password = Password_Passwordbox.Password.Trim();
                request.ConfirmPassword = Password_Passwordbox.Password.Trim();
                await _registerViewModel.RegisterUserAsync();

                ChangePageToLogin();
            }
        }
        catch
        {
            ShowErrorMessage();
        }
        finally
        {
            Register_Button.IsEnabled = true;
        }
    }

    private void ShowErrorMessage()
    {
        RegisterError_TextBlock.Visibility = Visibility.Visible;
    }

    private bool ValidateUser()
    {
        IErrorable registerError = new RegisterError
        {
            UsernameValidity = Username_TextBox.ValidateValidStringLength(4, 20),
            FirstNameValidity = FirstName_TextBox.ValidateHasInput(),
            LastNameValidity = LastName_TextBox.ValidateHasInput(),
            PasswordValidity = Password_Passwordbox.ValidatePassword(),
            ConfirmPasswordValidity =
                ConfirmPassword_PasswordBox.ValidateMatchPassword(Password_Passwordbox),
            EmailValidity =
                Email_TextBox.ValidateMatchPattern(RegexPattern.EmailAddress, "Email Address"),
            PhoneNumberValidity =
                PhoneNumber_TextBox.ValidateMatchPattern(RegexPattern.PhoneNumber, "Phone number")
        };

        return registerError.IsValid();
    }


    private void To_Login_Click(object sender, RoutedEventArgs e)
    {
        ChangePageToLogin();
    }

    private void ChangePageToLogin()
    {
        _mainWindow.FrMain.Content = _mainWindow.GetLoginPage();
    }
}
