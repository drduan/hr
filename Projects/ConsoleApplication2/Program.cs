using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
//using System.IO.Directory;
//using System.DirectoryInfo;



// goto 语句可以避免使代码陷入混乱  是控制什么时候执行哪些代码的方式 过多使用这个技巧将使代码晦涩难懂
//goto labelname;

// C# 和c++是有区别的 在c++中运行完一个case以后 可以运行下一个case 语句
namespace ConsoleApplication1
{
    class Program
    {


        public  delegate void  A();
        public static  void AA()
        {

        }
        static void Main(string[] args)
        {
            Console.WriteLine();
            //A a = new A(AA);
            //Console.WriteLine("" + DateTime.Now);
            //IPAddress[] addressList1 = Dns.GetHostAddresses("localhost");//会返回所有地址，包括IPv4和IPv6   
            //IPAddress[] addressList = Dns.GetHostAddresses("cs-PC");//会返回所有地址，包括IPv4和IPv6   
            //foreach (IPAddress ip in addressList)
            //{
            //    Console.WriteLine("" + ip.ToString());
            //}
            //Console.ReadKey();
            //Func<> aa = AA

        

        }



        //public void MyFunction(string label, params int[] args,bool showlabel)
        //{
        //如果要用Params可以传递指定类型的多个参数 如果不用params只能传递指定类型的一个参数   
        //params参数必须是形参表中最后一个参数 
        //ref 关键字使参数按引用传递   
        //若要调用ref参数 方法定义和调用方法都必须使用ref参数 属性不是变量 因此不能作为ref参数传递 
         // out 关键字会导致参数通过引用来传递 ref要求参数必须在传递之前初始化 out不需要初始化 但需要方法返回之前赋值
        //}
    }
}
