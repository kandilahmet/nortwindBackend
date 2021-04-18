using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }

        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {  //invocation => Bu bizim Metodumuzu temsil ediyor. Metodumuzu virtual metodlara parametre olarak veriyoruz.
            var isSuccess = true;
            OnBefore(invocation);//Metoddan önce çalışşın
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);//Hata Aldığında çalışşın
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation); // Başarılı olduğunda çalışşın
                }
            }
            OnAfter(invocation);//Metoddan çıkarken çalışşın
        }
    }
}
