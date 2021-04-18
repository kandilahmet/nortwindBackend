using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        /// <summary> 
        ///  verilen securityKey'i base64 formatına getirir ve symetricKey(Simetrik Anahtar değerini)oluşturur.
        /// </summary>
        /// <param name="securityKey">appsettings.json dosyasında belirtilen securityKey</param>
        /// <returns>Oluşturulan Symetric Security Key döner </returns>
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }

    }
}
