using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;

namespace MethodInvoker
{
    public static class MethodInvokerHelper
    {
        public static void CallMethod(List<dynamic> @params, string methodName, Type classType)
        {
            MethodInfo methodInfo = GetCorrectOverloadedMethod(classType.GetMethods(), methodName, @params);
            if (methodInfo == null)
            {
                throw new Exception("No method or method overload found");
            }

            List<object> convertedParams = new List<object>();
            var methodParameters = methodInfo.GetParameters();

            for (int i = 0; i < methodParameters.Length; i++)
            {
                convertedParams.Add(Convert.ChangeType(@params[i], methodParameters[i].ParameterType));
            }

            var obj = Activator.CreateInstance(classType);

            methodInfo.Invoke(obj, convertedParams.ToArray());
        }

        private static MethodInfo GetCorrectOverloadedMethod(MethodInfo[] methods, string methodName, List<dynamic> passedParameters)
        {
            var methodsMatchingProvidedNumberOfArguments = methods.Where(method => method.GetParameters().Length == passedParameters.Count && method.Name == methodName).ToList();
            foreach (var method in methodsMatchingProvidedNumberOfArguments)
            {
                var passedParametersTypes = passedParameters.Select(passedParameter => passedParameter.GetType()).ToList();
                var methodParameterTypes = passedParameters.Select(passedParameter => passedParameter.GetType()).ToList();

                if (Enumerable.SequenceEqual(passedParametersTypes, methodParameterTypes))
                {
                    return method;
                }
            }

            return null;
        }
    }
}