using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        /// <summary>
        /// Bu bizim Token üreten Metodumuzun prototipi
        /// Kullanıcı , authenticate olduktan sonra (k adı ve parolasını girip doğruladıktan sonra) 
        /// bu kullanıcının veritabanından tanımlı claim'lerini bulup 
        /// bu claim'leri içeren JWT oluşturacak. Daha sonra bu JWT kullanıcı ile paylaşılır. Bu bizim müşteriye verdiğimiz kullanıcının 
        /// istek yapmasını sağlayan AccessToken'dır
        /// OperationClaim => Kullanıcının Veritabanında Kayıtlı olan yetkileri
        /// User => Token hangi kullanıcı için oluşturulacak.
        /// </summary>
        /// <returns></returns>
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
       
    }
}
