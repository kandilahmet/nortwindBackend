using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///  serviceCollection nesnesine Module'lar içerisinde belirtilmiş olan Servislerin her birinin tek tek Load metodu yardımı ile ninject edilmesi 
        ///  Bütün Servisler Container'a dahil edildikten sonra ServiceTool içinde bulunan Create Metodu ile bir tane static ServiceProvide a bu değerleri
        ///  atar ayrıca bütün bir araya getirilen IoC Container'a atılan service'ler geri döndürülür.
        /// </summary>
        /// <param name="serviceCollection">this ile temsil edilen, içerisine yeni servisler dahil/ninject edilecek ServiceCollection</param>
        /// <param name="modules">İçerisinde ninject edilecek Servisler ve bu işlemi yapacak olan Load Metodu tanımlı</param>
        /// <returns>IoC Container'a toplanmış bütün Service Collection</returns>
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}
