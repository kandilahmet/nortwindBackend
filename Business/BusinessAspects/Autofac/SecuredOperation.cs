using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    /// <summary>
    /// JWT için
    /// </summary>
    public class SecuredOperation:MethodInterception
    {
        private string[] _roles;
        //Kullanıcının yaptığı  her request için bir HttpContext oluşturulur.
        //IHttpContextAccessor de HttpContext nesnesini işaret eder/tutar. IoC mekanızmasını kullanarak HttpContext e erişebiliriz.
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Metodlarda yetkilerin belirtildiği constructor
        /// </summary>
        /// <param name="roles">verilen yetkiler / yetkiler virgül ile ayrılır.</param>
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            //Aspect yapısında Injection yaparsak Interface'e (IHttpContextAccessor) verdiğimiz Class'ı göremeyiz, erişemeyiz.
            //Bu sebepten dependency'leri yakalamak/erişebilmek için bir ServiceTool class yazıp Injection yapmıza erişip okuyabileceğimiz bir yapı.
            //Böylece Autofac de yaptığımız Inject değerle içerisnde IHttpContextAccessor ün temsil ettiği class'a erişebiliriz. Yani HttpContext'e
            //Microsoft.Extensions.DependencyInjection kütüphanesini de ekledikten sonra GetService Metodu kullanılabilir hale gelmiş olur.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        /// <summary>
        /// Metod içerisine girmeden Attribute içerisinde verilen Roller ile User'ın Request'i içerisindeki Claim'ler içinde Role bazlı Claimleri karşılaştırır.
        /// Uyuşan varsa return eder ve 
        /// </summary>
        /// <param name="invocation">Bizim SecuredOperation Attribute ile işlem yaptığımız Metod</param>
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            var asss = _httpContextAccessor.HttpContext.User.Identity.Name;
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
