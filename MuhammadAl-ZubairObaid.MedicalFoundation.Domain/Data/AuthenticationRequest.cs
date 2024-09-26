using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Data
{
    /// <summary>
    /// API authentication request
    /// </summary>
    public class AuthenticationRequest
    {
        private string password;
        private string username;

        /// <summary>
        /// Authenticating user name. Emails are not allowed
        /// </summary>
        public string Username { get => username; set { if (Regex.IsMatch(value, "(\\b[\\w\\.-]+@[\\w\\.-]+\\.\\w{2,4}\\b)")) throw new InvalidOperationException("Emails are not allowed."); username = value; } }
        /// <summary>
        /// Authenticating user password. Must be at least 8 characters
        /// </summary>
        public string Password { get => password; set { if (!Regex.IsMatch(value, "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")) throw new InvalidOperationException("Password length should be at least 8 characters, containing alphabets and numbers only."); password = value; } }
    }
}
