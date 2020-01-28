using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallMethodWithListOfArguments.TestClass
{
    public class TestClass1
    {
        public void Method1()
        {
            Console.WriteLine($"Method 1 called with no arguments");
            Console.WriteLine();
        }

        public void Method1(int argument)
        {
            Console.WriteLine($"Method 1 called with argument: {argument}");
            Console.WriteLine();
        }

        public void Method1(int argument, string argument2)
        {
            Console.WriteLine($"Method 1 called with arguments: {argument} and {argument2}");
            Console.WriteLine();
        }
    }
}