using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EbookStore.Presentation.Validator
{
    public static class TextInputWithGroupBoxValidator
    {
        public static bool ValidateValidStringLength(this TextBox input, int min, int max)
        {
            int textLength = input.Text.Trim().Length;
            GroupBox inputContainer = (GroupBox)input.Parent;

            bool result = true;
            if (textLength < min || textLength > max)
            {
                inputContainer.Header = $"Required, {min}-{max} characters";
                result = false;
            }
            else
            {
                inputContainer.Header = "";
            }
            return result;
        }

        public static bool ValidateHasInput(this TextBox input)
        {
            int textLength = input.Text.Trim().Length;
            bool result = true;
            GroupBox inputContainer = (GroupBox)input.Parent;

            if (textLength <= 0)
            {
                inputContainer.Header = $"This field is required";
                result = false;
            }
            else
            {
                inputContainer.Header = "";
            }
            return result;
        }

        public static bool ValidateMatchTextBox(this TextBox input, TextBox target, string targetName)
        {
            string textInput = input.Text.Trim();
            string targetText = target.Text.Trim();
            bool result = true;
            GroupBox inputContainer = (GroupBox)input.Parent;

            if (!textInput.Equals(targetText) || !input.ValidateHasInput())
            {
                inputContainer.Header = $"Must match {targetName}";
                result = false;
            }
            else
            {
                inputContainer.Header = "";
            }
            return result;
        }

        public static bool ValidateMatchPattern(this TextBox input, string pattern, string patternMeaning)
        {
            string textInput = input.Text.Trim();
            bool result = true;
            GroupBox inputContainer = (GroupBox)input.Parent;

            if (!Regex.IsMatch(textInput, pattern))
            {
                inputContainer.Header = $"{patternMeaning} not valid";
                result = false;
            }
            else
            {
                inputContainer.Header = "";
            }
            return result;
        }
    }
}
