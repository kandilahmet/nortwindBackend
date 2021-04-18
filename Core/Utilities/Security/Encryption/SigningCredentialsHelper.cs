using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        /// <summary> 
        /// Verilen SymetricSecurityKey'i HMAC algoritması kullanarak imzalar.
        /// </summary>
        /// <returns>HMAC Algoritması ile Imzalanan Security Key</returns>
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
