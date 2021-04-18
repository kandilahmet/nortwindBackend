using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependecyResolvers
{
    public class AutofacBusinessModule:Module
    {
       /// <summary>
       /// Burada Business katmanının IOC yapılanmasını ayarlıyoruz.
       /// Daha sonra hangi Projede kullanacaksak oraya ekleyeceğiz.
       /// </summary>
       /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>(); 
            builder.RegisterType<UserManager>().As<IUserService>();
           

            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>(); 

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<AuthManager>().As<IAuthService>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();//Çalışan uygulama içerisinde

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()//İmplemente edilmiş Interface leri bul
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()// İmplemente edilmiş Interface ler için AspectInterceptorSelector'ı çağır
                }).SingleInstance();
        }
    }
}
