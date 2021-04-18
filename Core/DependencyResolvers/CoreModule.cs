using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    /// <summary>
    /// Her projede lazım olabilecek injection'ların Yönetiminin yapıldığı Class
    /// </summary>
    public class CoreModule : ICoreModule
    {
        /// <summary>
        /// IoC mekanizmasına istediğimiz servisleri ekleyebiliriz.
        /// </summary>
        /// <param name="serviceCollection">Parametre ile verilen ServiceCollection nesnesi</param>
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();//  IMemoryCache'e InMemoryCache'in bir örneğini oluşturup veriyor.

            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
