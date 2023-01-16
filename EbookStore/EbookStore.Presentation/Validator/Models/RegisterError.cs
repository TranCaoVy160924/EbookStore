using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Presentation.Validator.Models
{
    class RegisterError: IErrorable
    {
        public bool UsernameValidity { get; set; }
        public bool FirstNameValidity { get; set; }
        public bool LastNameValidity { get; set; }
        public bool PasswordValidity { get; set; }
        public bool ConfirmPasswordValidity { get; set; }
        public bool EmailValidity { get; set; }
        public bool PhoneNumberValidity { get; set; }

        public bool IsValid()
        {
            if (!UsernameValidity ||
                !FirstNameValidity ||
                !LastNameValidity ||
                !PasswordValidity || 
                !ConfirmPasswordValidity ||
                !EmailValidity || 
                !PhoneNumberValidity)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
