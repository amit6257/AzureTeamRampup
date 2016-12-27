using System;

namespace LearnCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            learnDelegate();
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