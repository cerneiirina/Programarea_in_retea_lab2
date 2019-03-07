using System;
using System.Threading;

namespace lab2
{
    class Program
    {
        static AutoResetEvent waitHandler = new AutoResetEvent(false);

        static Thread first;
        public static void SecondThread()
        {
            Console.WriteLine("Second thread starts");
            waitHandler.Set();
        }
        public static void ThirdThread()
        {
            Console.WriteLine("Third thread starts");
            waitHandler.WaitOne();
            Thread fifth = new Thread(() => FifthThread());
            fifth.Start();
        }

        public static void FifthThread()
        {
            Console.WriteLine("Fifth thread start");
            Console.ReadKey();
        }

        public static void FourthThread()
        {
            Console.WriteLine("Fourth thread start");
            waitHandler.Set();
        }

        public static void firstThread()
        {
            Console.WriteLine("First thread started");
            Thread secondTh = new Thread(() => SecondThread());
            Thread thirdTh = new Thread(() => ThirdThread());
            Thread fourthTh = new Thread(() => FourthThread());
            secondTh.Start();
            waitHandler.WaitOne();
            thirdTh.Start();
            fourthTh.Start();
        }



        static void Main(string[] args)
        {
            onsole.WriteLine("-------------------------------------------");
            Thread.Sleep(2000);
            first = new Thread(() => firstThread());
            first.Start();
        }
    }
}
