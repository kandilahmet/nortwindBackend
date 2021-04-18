using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        //ClaimsPrincipal => Kullanıcının gönderdiği JWT deki Claim lerine ulaşmak için.Net'in bir class'ı


        /// <summary>
        /// claimType ile verilen tip deki Claim leri döndürecek.
        /// </summary>
        /// <param name="claimsPrincipal"></param>
        /// <param name="claimType"></param>
        /// <returns>Claims</returns>
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var reseult = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return reseult;
        }
        /// <summary>
        /// ClaimType Role olanları döndürür
        /// </summary>
        /// <param name="claimsPrincipal"></param>
        /// <returns>Role Claims</returns>
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
