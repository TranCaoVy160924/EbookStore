using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EbookStore.Presentation.Validator;

public static class PasswordWithGroupBoxValidator
{
    public static bool ValidateMatchPassword(this PasswordBox input, PasswordBox target)
    {
        string passwordInput = input.Password.Trim();
        string targetPassword = target.Password.Trim();
        bool result = true;
        GroupBox inputContainer = (GroupBox)input.Parent;

        if (!passwordInput.Equals(targetPassword))
        {
            inputContainer.Header = "Confirm must match password}";
            result = false;
        }
        else
        {
            inputContainer.Header = "";
        }
        return result;
    }

    public static bool ValidatePassword(this PasswordBox input)
    {
        string passwordPattern = RegexPattern.Password;

        string passwordInput = input.Password.Trim();
        bool result = true;
        GroupBox inputContainer = (GroupBox)input.Parent;

        if (!Regex.IsMatch(passwordInput, passwordPattern))
        {
            inputContainer.Header = "Require upper, lower, number and special";
            result = false;
        }
        else
        {
            inputContainer.Header = "";
        }
        return result;
    }
}
