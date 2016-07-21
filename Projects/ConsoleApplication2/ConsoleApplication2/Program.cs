using ExifWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ExifWorks.ExifManager;

namespace ConsoleApplication2
{
    class Program
    {

        static bool done;
        static Object locker = new object();

        //static int TakesAWhile(int data,int ms)
        //{


        //    Thread.Sleep(2000);

        //    return 1000;
        //}
        //public delegate int getsum(int data,int ms);
        static Task<Int32> rt = null;
        static void Main(string[] args)
        {

            Thread thread3 = new Thread(delegate () { Console.WriteLine("匿名委托"); });
            Thread thread1 = new Thread( () => { Console.WriteLine("匿名委托"); });

            //rt = new Task<Int32>    (m => 10,1000);
            //Sum sum = new Sum(Add);
            //Sum dd = Add

            ;
            //Thread rer = new Thread((int we,int q)=>  Console.WriteLine("asdasd"));
            //rer.Start();
            //rer(1,2);
            //rer.Join();


            //Thread t = new Thread(Go);
            //t.Start();
            //t.Join();
            //Go();


            //getsum a = TakesAWhile;



        }

        static void Go()
        {
            //lock(locker)
            //{
            if (!done)
            {
                Console.WriteLine("Done");
                Console.ReadKey();

                done = true;
            }
        }
        //}

        delegate void Sum(int x, int y);
        static void Add(int x, int y)
        {

            Console.WriteLine(x + y);
        }
    }
}
