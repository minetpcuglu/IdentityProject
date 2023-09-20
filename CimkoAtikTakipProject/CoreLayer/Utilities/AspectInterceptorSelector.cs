using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CoreLayer.Utilities
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        private IInterceptorSelector _interceptorSelectorImplementation;

       

        public Castle.DynamicProxy.IInterceptor[] SelectInterceptors(Type type, MethodInfo method, Castle.DynamicProxy.IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            //var methodAttributes =
            //    (type.GetMethod(method.Name) ??
            //     throw new InvalidOperationException("AspectInterceptorSelector method.Name null geldi."))
            //    .GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            //classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(DatabaseLogger)));

            return classAttributes.OrderBy(o => o.Priority).ToArray();
        }
    }
}
