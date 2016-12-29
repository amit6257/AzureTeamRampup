using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://www.dotnetperls.com/lambda
namespace LearnCsharp
{
    class LearnTask
    {
        public static void testTask()
        {
            testFunc();
            Console.Read();
        }

        private static void testFunc()
        {
            // Func<returntype, param1, param2>
            Func<int> f1 = () => { return 3;};
            int d = f1.Invoke();
            Console.WriteLine(d);


            Func<int, int> f2 = (int cx) => { return cx; };
            Console.WriteLine(f2.Invoke(23));

            Func<int, int, int, string> f3 = (int ds, int u, int p) => { return ds + u + p+ ""; };
            Console.WriteLine(f3.Invoke(1, 9, 8));

            Action ac = () => { Console.WriteLine("I am an action"); };
            ac.Invoke();

            // Lambda as action
            passLambdaAsParameter1(() => { });
            passLambdaAsParameter1(() => { Console.WriteLine("Passing lambda as param as an action"); });

            // Lambda as Func
            passLambdaAsParameter2(() => { return 9; });
            passLambdaAsParameter3((int x, int y) => {print(390); return x + y; });
            passLambdaAsParameter4((int op) => { return "hello"; });
            passLambdaAsParameter5((int op, int uu) => { return "hello -"+ (op + uu); });
        }

        private static void passLambdaAsParameter4(Func<int, string> func)
        {
            func.Invoke(34);
        }

        private static void passLambdaAsParameter5(Func<int, int, string> func)
        {
            Console.WriteLine(func.Invoke(34, 90));
        }

        private static void passLambdaAsParameter3(Func<int, int, int> func)
        {
            Console.WriteLine(func.Invoke(4, 3));
        }

        private static void passLambdaAsParameter2(Func<int> myFunc)
        {
            Console.WriteLine(myFunc.Invoke());
        }

        private static void passLambdaAsParameter1(Action a)
        {
            a.Invoke();
        }

        private static void print(int e)
        {
            Console.WriteLine(e);
        }

        /*private static void test1()
        {
            Task<int> t = getTask();
        }

        private static Task<int> getTask()
        {
            return Call2((myvar) => newfn(myvar));
        }

        private Task<int> Call2(Func<> f)
        {
            return new Task<int>(() => { return 3; });
        }*/
    }
}
