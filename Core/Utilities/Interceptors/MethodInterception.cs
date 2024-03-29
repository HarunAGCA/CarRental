﻿using Castle.DynamicProxy;
using Core.Utilities.Exceptions;
using Core.Utilities.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
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
        {
            var isSuccess = true;
            try
            {
                OnBefore(invocation);
                invocation.Proceed();
            }
            catch (ValidationException validationException)
            {
                string errors = "";
                foreach (var error in validationException.Errors)
                {
                    errors += error.ErrorMessage + "\n";
                }

                var returnType = invocation.Method.ReturnType;
                if (returnType.GenericTypeArguments.Any())
                {
                    invocation.ReturnValue = Activator.CreateInstance(Type.GetType($"Core.Utilities.Results.ErrorDataResult`1[{returnType.GenericTypeArguments[0].FullName}]"), errors);
                    return;
                }

                invocation.ReturnValue = new ErrorResult(errors);
                return;
            }
            catch (AuthorizationException authorizationException)
            {
                var returnType = invocation.Method.ReturnType;
                if (returnType.GenericTypeArguments.Any())
                {
                    invocation.ReturnValue = Activator.CreateInstance(Type.GetType($"Core.Utilities.Results.ErrorDataResult`1[{returnType.GenericTypeArguments[0].FullName}]"), authorizationException.Message);
                    return;
                }
                invocation.ReturnValue = new ErrorResult(authorizationException.Message);
                return;
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);

                var returnType = invocation.Method.ReturnType;
                if (returnType.GenericTypeArguments.Any())
                {
                    invocation.ReturnValue = Activator.CreateInstance(Type.GetType($"Core.Utilities.Results.ErrorDataResult`1[{returnType.GenericTypeArguments[0].FullName}]"), "Bir Hata Oluştu");
                    return;
                }
                invocation.ReturnValue = new ErrorResult("Bir Hata Oluştu");
                return;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
