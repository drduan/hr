using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Text;
using System.Drawing.Imaging;
using System.Windows;
using EXIF文件修改器;
using System.Collections.Generic;
using System.Windows.Media.Animation;
using System.IO;

namespace WpfApplication4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
  
        Stream fstream = null;
        private System.String ImgUrl = "";
        private bool openStatus = false;
        System.Windows.Point aBefore = new System.Windows.Point(); //鼠标点击前坐标
        System.Windows.Point bBefore = new System.Windows.Point(); //控件坐标
        bool isMove = false;//是否需要移动

        public MainWindow()
        {
            InitializeComponent();
            textBlock.Visibility = Visibility.Hidden;
            textBlock.AddHandler(TextBox.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this
                .textBlock_MouseLeftButtonDown), true);
            textBlock.AddHandler(TextBox.MouseLeftButtonUpEvent, new MouseButtonEventHandler(this
                .textBlock_MouseLeftButtonUp), true);
            //MeasureImg.Click += new EventHandler(delegate () { }); //routedeventhandler
            //MeasureImg.AddHandler(Button.PreviewMouseDownEvent,new MouseEventHandler(DrawLine) );

        }


       
        private void GetImg_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = ".jpg";
            ofd.Filter = "image file|*.jpg";
            if (ofd.ShowDialog() == true)
            {
                this.ImgUrl = ofd.FileName;

                ImageBrush ib = new ImageBrush();
                fstream = IOutil.FileToStream(ImgUrl);
                var bitmap = IOutil.BytesToBitmap(IOutil.StreamToBytes(fstream));
                var bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(),
                                                                                      IntPtr.Zero,
                                                                                      Int32Rect.Empty,
                                                                                      BitmapSizeOptions.FromEmptyOptions()
                      );

                var brush = new ImageBrush(bitmapSource);
                ib.ImageSource = bitmapSource;
                ib.Stretch = Stretch.Fill;
                Imagee.Background = ib;
            }



        }



        private void AddRemark(object sender, RoutedEventArgs e)
        {
            if (openStatus == false)
            {
                if (ImgUrl != "")
                {
                    textBlock.Visibility = Visibility.Visible;
                    openStatus = true;
                    System.Drawing.Image img = System.Drawing.Image.FromStream(fstream);
                    PropertyItem[] PropertyItems = img.PropertyItems;
                    PropertyItem propItem36867 = img.GetPropertyItem(0x9C9C);
                    textBlock.Text = ""+Encoding.Unicode.GetString(propItem36867.Value);
                }
                else
                {
                    MessageBox.Show("请导入图片");
                }
            }
            else
            {
                textBlock.Visibility = Visibility.Hidden;
                openStatus = false;
            }

        }
        /// <summary>  
        /// 从文件读取 Stream  
        /// </summary>  

        private void textBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //if (e.OriginalSource.GetType() == typeof(TextBox))
            //{
            this.aBefore = e.GetPosition(null);
            this.bBefore = new System.Windows.Point(Canvas.GetLeft(textBlock), Canvas.GetTop(textBlock));
            isMove = true;
            textBlock.CaptureMouse();
            //}
        }

        private void textBlock_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.OriginalSource.GetType() == typeof(TextBox))
            {
                isMove = false;
                textBlock.ReleaseMouseCapture();
            }
        }

        private void textBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {


            if (e.OriginalSource != null && e.OriginalSource.GetType() == typeof(TextBox) && isMove)
            {
                System.Windows.Point p = e.GetPosition(null);
                double ax = bBefore.X + p.X - aBefore.X;
                double ay = bBefore.Y + p.Y - aBefore.Y;
                if (-242d < ax && ax <= Imagee.ActualWidth + 242d && ay >= -109d && ay <= Imagee.ActualHeight + 182d)
                {
                    Canvas.SetLeft(textBlock, ax);
                    Canvas.SetTop(textBlock, ay);
                    


                }
                else
                {
                    Canvas.SetLeft(textBlock, 0d);
                    Canvas.SetTop(textBlock, 0d);
                }
            }


        }

        private void textBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            String Y = textBlock.Text;
            System.Drawing.Image img = System.Drawing.Image.FromStream(fstream);
            System.Drawing.Imaging.PropertyItem[] PropertyItems = img.PropertyItems;
            byte[] b = Encoding.Unicode.GetBytes(Y);
            PropertyItem propItem36867 = img.GetPropertyItem(0x9C9C);
            propItem36867.Value = b;
            img.SetPropertyItem(propItem36867);
            img.Save(ImgUrl + ".temp.jpg");
            System.IO.File.Delete(ImgUrl);
            System.IO.File.Move(ImgUrl + ".temp.jpg", ImgUrl);
            System.IO.File.Delete(ImgUrl + ".temp.jpg");

        }

        private void DrawLine(object sender, RoutedEventArgs e)
        {
            //var points =
            // new List<System.Windows.Point>()
            // {
            //       new  System.Windows.Point(10, 10),
            //       new  System.Windows.Point(90, 90),
            //       new  System.Windows.Point(60, 10),
            //       new  System.Windows.Point(250, 90),
            //       new  System.Windows.Point(10, 10)
            // };
            //var sb = new Storyboard();
            //for (int i = 0; i < points.Count - 1; i++)
            //{
            //    var lineGeometry = new LineGeometry(points[i], points[i]);
            //    System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
            //    //path.Stroke = new  System.Windows.Media.Brush();
            //    path.StrokeThickness = 2;
            //    path.Data = lineGeometry;
            //    Imagee.Children.Add(path);
            //    var animation =
            //        new PointAnimation(points[i], points[i + 1], new Duration(TimeSpan.FromMilliseconds(1000)))
            //        {
            //            BeginTime = TimeSpan.FromMilliseconds(i * 1010)
            //        };
            //    sb.Children.Add(animation);
            //    RegisterName("geometry" + i, lineGeometry);
            //    Storyboard.SetTargetName(animation, "geometry" + i);
            //    Storyboard.SetTargetProperty(animation, new PropertyPath(LineGeometry.EndPointProperty));
            //}
            //MouseDown += (s, we) => sb.Begin(this);

        }
    }
}
