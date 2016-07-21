using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication4Canvals
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            SetValue(Window.WidthProperty, 22222d);
            DisplayCanvas();
        }

        public void DisplayCanvas()
        {




            Canvas canv = new Canvas();
            //canv.Background(new Brush());
            this.Content = canv;
            canv.Margin = new Thickness(1,1,1,1);
            canv.Background = new SolidColorBrush(Colors.White);


            //Rectangle

            Rectangle r = new Rectangle();

            r.Fill = new SolidColorBrush(Colors.Red);

            r.Stroke = new SolidColorBrush(Colors.Red);

            r.Width = 200;

            r.Height = 140;

            r.SetValue(Canvas.LeftProperty, (double)200);

            r.SetValue(Canvas.TopProperty, (double)120);

            canv.Children.Add(r);

            //Ellipse

            Ellipse el = new Ellipse();

            el.Fill = new SolidColorBrush(Colors.Blue);

            el.Stroke = new SolidColorBrush(Colors.Blue);

            el.Width = 240;

            el.Height = 80;

            el.SetValue(Canvas.ZIndexProperty, 1);

            el.SetValue(Canvas.LeftProperty, (double)100);

            el.SetValue(Canvas.TopProperty, (double)80);

            canv.Children.Add(el);


        }
    }
}
