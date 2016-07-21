using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication4Canvals
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_MouseDoubleClick(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("asd" + (sender as FrameworkElement).Name);


            //MessageBox.Show("" + e.MouseDevice + "" + e.ChangedButton + "" + e.StylusDevice);

            //if (e.ClickCount ==2)
            //{

            //    Control control1 = (Control)sender;
            //    MessageBox.Show("device"+e.MouseDevice+"\n changedbutton"+e.ChangedButton+"\n stylusdevice"+e.StylusDevice);
            //    MouseButtonEventArgs args = new MouseButtonEventArgs(e.MouseDevice,e.Timestamp,e.ChangedButton,e.StylusDevice);
            //    if((e.RoutedEvent == UIElement.PreviewMouseLeftButtonUpEvent) || (e.RoutedEvent == UIElement.PreviewMouseLeftButtonDownEvent))
            //    {
            //        args.RoutedEvent = PreviewMouseDoubleClickEvent;
            //        args.Source = e.OriginalSource;
            //        //args.OverrideSource(e.Source); // 注意这里对Source的处理
            //        //control1.OnPreviewMouseDoubleClick(args); // 发出双击的Preview消息
            //    }
            //    else
            //    {
            //        args.RoutedEvent = MouseDoubleClickEvent;
            //        args.Source = e.OriginalSource;
            //        //args.OverrideSource(e.Source);
            //        //control.OnMouseDoubleClick(args); // 发出双击消息
            //    }
            //    if (args.Handled)
            //        e.Handled = true; // 将Handled设置为true，从而使该消息被隐藏
            //}

            //Thread t = new Thread(() => Console.WriteLine(""));
            //dynamic a = 12;
            //           Func<string, int> test1;
            //Thread t1 = new Thread(new ParameterizedThreadStart(a)); //带参数的线程函数
            //Func<string, string> f = (string a) => { return ""; }; 
            //public delegate void BlukPrintSomething();

            //BlukPrintSomething  a = () => Console.WriteLine("");




        }

    }
    }

