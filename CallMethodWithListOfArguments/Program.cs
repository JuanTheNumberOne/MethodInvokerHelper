using CallMethodWithListOfArguments.TestClass;
using MethodInvoker;
using System;
using System.Collections.Generic;

namespace CallMethodWithListOfArguments
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                testMethodInvocationByListOfArguments();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

            Console.Read();
        }

        private static void testMethodInvocationByListOfArguments()
        {
            var listOfArguments = new List<dynamic>();

            MethodInvokerHelper.CallMethod(listOfArguments, "Method1", typeof(TestClass1));

            listOfArguments.Add(500);
            MethodInvokerHelper.CallMethod(listOfArguments, "Method1", typeof(TestClass1));

            listOfArguments.Add("FooBarBaz");
            MethodInvokerHelper.CallMethod(listOfArguments, "Method1", typeof(TestClass1));

            //listOfArguments.Add("Throw Error");
            //MethodInvokerHelper.CallMethod(listOfArguments, "Method1", typeof(TestClass1));
        }
    }
}