using System;

// https://docs.microsoft.com/en-us/dotnet/articles/csharp/programming-guide/delegates/index
// https://docs.microsoft.com/en-us/dotnet/articles/csharp/programming-guide/statements-expressions-operators/anonymous-methods
namespace LearnCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            learnDelegate();
            addDelegates();
            
            anonymousDelegate();
            delegateWithReturnType();
            Console.Write("Exiting main method");
            Console.Read();
        }

        private delegate int DelWithReturnType();
        private static void delegateWithReturnType()
        {
            DelWithReturnType del = testMethod;
            int e = del();
            Console.WriteLine("returned value = " + e);

        }

        private static int testMethod()
        {
            Console.WriteLine("hello World!!");
            return 34;
        }

        private static void anonymousDelegate()
        {
            Del d = delegate(string s)
            {
                Console.Write(s);
                Console.Read();
            };

            d("delegate created as an anonumous method, not a named method");
            Console.Read();
        }

        private static void addDelegates()
        {

            Del d1 = DelegateMessage;
            Del d2 = DelegateMessage;

            Del d3 = d1 + d2;
            d3("nice ");
        }

        private static void learnDelegate()
        {
            Del handler= DelegateMessage;
            handler("hello , I am a delegate method");
        }

        private delegate void Del(string mesage);
        private static void DelegateMessage(string s)
        {
            Console.Write(s);
            Console.Read();
        }
    }
}