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
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Aşağıdaki kod Reflection'dur.Reflection çalışma anında bir şeyleri çalıştırabilmemizi sağlar.
            //Mesela çalışma zamanında new leme işlemini yapmak istiyoruz o zaman aşağıdaki Reflection(Activator.CreateInstance) işlemini gerçekleştiriyoruz
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //Aşağıdaki kodda _validatorType(ProductValidator)'ın çalışma tipini bulmamızı söyler
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //Aşağıdaki kodda invocation(metodun) Arguments(parametrelerine) Where(bak) entityType denk geleni bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //Her birini tek tek gez ValidationTool kullanarak
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
