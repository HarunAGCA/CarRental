using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using Core.Utilities.Results;
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
                throw new Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }
       

        public override void Intercept(IInvocation invocation)
        {
            try
            {
                var validator = (IValidator)Activator.CreateInstance(_validatorType);
                var entityType = _validatorType.BaseType.GetGenericArguments()[0];
                var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
                foreach (var entity in entities)
                {
                    ValidationTool.Validate(validator, entity);
                }

                invocation.Proceed();
            }
            catch (ValidationException validationException)
            {
                var returnType = invocation.Method.ReturnType;
                if (returnType.GenericTypeArguments.Any())
                {
                    invocation.ReturnValue = Activator.CreateInstance(Type.GetType($"Core.Utilities.Results.ErrorDataResult`1[{returnType.GenericTypeArguments[0].FullName}]"),validationException.Message);
                    return;
                }
                invocation.ReturnValue = new ErrorResult(validationException.Message);
                return;
            }
            catch (Exception exception)
            {
                throw;
            }

        }
    }

}


