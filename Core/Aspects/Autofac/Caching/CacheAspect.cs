using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //invocation => Bizim Metodu Temsil Ediyordu.
            //invocation.Method.ReflectedType.FullName => Metodun Namespace'i + Interface'i(Interface Üzerinden çalıştığı için) verir.
            //invocation.Method.Name => Metodun ismini verir.
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");

            //Metodun parametrelerini listeye çevir.
            var arguments = invocation.Arguments.ToList();

            //Metod ismi ve parametrelerine göre bir key oluşturduk.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

            //Bellekte bu oluşturduğumuz Key için bir kayıt var mı ?
            if (_cacheManager.IsAdd(key))
            {
                //Eğer varsa;
                //invocation'ın temsil ettiği metod için bir return  değeri set ediyoruz.
                invocation.ReturnValue = _cacheManager.Get(key);

                //Bu metod dan çıkıyoruz.
                return;
            }
            //Eğer yoksa
            //invocation'ın temsil ettiği metodun çalışmasına devam et
            invocation.Proceed();

            //invocation'ın temsil ettiği metod'dan dönen değeri Cache'e ekle
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
