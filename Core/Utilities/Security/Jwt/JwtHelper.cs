
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }//appsettings.json dosyasındaki değerleri okumamıza yarar.
        private TokenOptions _tokenOptions;//appsettings.json içerisinde TokenOptions object'in class olarak karşılığıdır.
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //appsettings den gelen TokenOptions değerlerini class field ları ile eşler.
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        /// <summary>
        ///  Access Token Oluşturacak ve Dışarıya açılacak Metod 
        /// </summary>
        /// <param name="user">Hangi kullanıcı için oluşturulacaksa</param>
        /// <param name="operationClaims">User'ın sahip olduğu Claim listesi</param>
        /// <returns>AccessToken</returns>
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.UtcNow.AddMinutes(_tokenOptions.AccessTokenExpiration);
           
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler(); //Token oluşturucu sınıfında bir örnek alıyoruz.            
            var token = jwtSecurityTokenHandler.WriteToken(jwt);//Token üretiyoruz.

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

       /// <summary>
       ///  Burada verilen parametreler ile JWT oluşturulur
       /// </summary>
       /// <param name="tokenOptions">appsettings.json dan gelen TokenOptions</param>
       /// <param name="user">Hangi kullanıcı için oluşturulacaksa</param>
       /// <param name="signingCredentials">Simetrik anahtarın HMAC ile şifrelenmiş Hali</param>
       /// <param name="operationClaims">User'ın sahip olduğu Claim listesi</param>
       /// <returns>JWT(Json Web Token)</returns>
        private JwtSecurityToken CreateJwtSecurityToken
            (TokenOptions tokenOptions, User user
            , SigningCredentials signingCredentials
            , List<OperationClaim> operationClaims
            )
        {//Oluşturulacak JWT için parametre değerleri set ediyoruz.
            var jwt = new JwtSecurityToken(
                 issuer: tokenOptions.Issuer,
                 audience: tokenOptions.Audience,
                 expires: _accessTokenExpiration,//Token süresini ... dk olarak belirliyorum
                 notBefore: DateTime.UtcNow,//Token üretildikten ne kadar süre sonra devreye girsin ayarlıyouz.
                 claims: SetClaims(user, operationClaims),
                 signingCredentials: signingCredentials
                );

            return jwt;
        }
        /// <summary>
        /// JWT de kullanılacak Claim'ler oluşturulur.
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="operationClaims">User'ın sahip olduğu Claimler</param>
        /// <returns>Claim Listesi</returns>
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();

            claims.AddRoles(operationClaims.Select(x => x.Name).ToArray());
            claims.AddEmail(user.Email);
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName($"{user.FirstName} {user.LastName}");

            return claims;
        }
    }
}
