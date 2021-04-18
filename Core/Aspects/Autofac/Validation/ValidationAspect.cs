using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    //Bu bir Attribute
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//Attribute'lara tipleri böyle atıyoruz.
                                                   //İlgili yerde bu attribute'ın kullanımı => [ValidationAspect(typeof(ProductValidator))]
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                //throw new System.Exception(AspectMessages.WrongValidationType);
                throw new System.Exception("Bu Tip/Tür/Sınıf bir Validator sınıfı/IValidator dan türemiş bir sınıf değil");
            }
            
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Activator.CreateInstance => Çalışma anında new yapar.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//ProductValidator ın bir Instance'ını oluştur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//ProductValidator BaseType Base class ını bul ve onun Generic argümanlarından ilk ini al.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//İlgili Metodun(invocation metodu temsil ediyordu)
            //Parametrelerini bul ve valition da kullanılan tip'e(Product) a eşit olanı getir.
            foreach (var entity in entities)
            {
                FluentValidationTool.Validate(validator, entity);//Fluet Validation 'u kullanarak Validate et.
            }
        }
    }
}
