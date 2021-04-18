using Castle.DynamicProxy;
using Core.Aspects.Autofac.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();// Class ın attribute larını oku
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);//Metod un attribute larını oku oradaki Interceptor(Aspect) leri bul
            classAttributes.AddRange(methodAttributes);
            // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));// Otomatik olarak sistemdeki bütün metodları log a dahil et.
           // classAttributes.Add(new PerformanceAspect(10));//Tüm Metodlara Attribute olarak eklemiş oluruz.

            return classAttributes.OrderBy(x => x.Priority).ToArray();//öncelik değerine göre sırala
        }
    }
}
