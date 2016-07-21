using System;
//using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Text;
using ExifWorks;
using System.Drawing.Imaging;
using System.IO;

namespace WpfApplication4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private System.String ImgUrl = "";
        private bool openStatus = false;
        Point aBefore = new Point(); //鼠标点击前坐标
        Point bBefore = new Point(); //控件坐标
        bool isMove = false;//是否需要移动

        public MainWindow()
        {
            InitializeComponent();
            textBlock.Visibility = Visibility.Hidden;
            textBlock.AddHandler(TextBox.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this
                .textBlock_MouseLeftButtonDown), true);
            textBlock.AddHandler(TextBox.MouseLeftButtonUpEvent, new MouseButtonEventHandler(this
                .textBlock_MouseLeftButtonUp), true);

        }

        private void GetImg_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = ".jpg";
            ofd.Filter = "image file|*.jpg;*.png";
            if (ofd.ShowDialog() == true)
            {
                this.ImgUrl = ofd.FileName;
                
            //  BitmapImage ewq = BitmapIma.;
 System.Drawing.Image img = System.Drawing.Image.FromFile(ImgUrl);
                ImageBrush ib = new ImageBrush();

                var bitmap = new System.Drawing.Bitmap(img);

                var bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(),

                                                                                      IntPtr.Zero,

                                                                                      Int32Rect.Empty,

                                                                                      BitmapSizeOptions.FromEmptyOptions()

                      );
        
               bitmap.Dispose();

                //   var brush = new ImageBrush(bitmapSource);

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

                    string coxp = new ExifManager(@ImgUrl).XPComment;

                    textBlock.Text = coxp;







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
            this.bBefore = new Point(Canvas.GetLeft(textBlock), Canvas.GetTop(textBlock));
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
                Point p = e.GetPosition(null);
                double ax = bBefore.X + p.X - aBefore.X;
                double ay = bBefore.Y + p.Y - aBefore.Y;
                if (-242d < ax && ax <= 182d + 242d && ay >= -109d && ay <= 350d + 182d)
                {
                    Canvas.SetLeft(textBlock, ax);
                    Canvas.SetTop(textBlock, ay);


                }
                else
                {
                    Canvas.SetLeft(textBlock, 0d);
                    Canvas.SetTop(textBlock, 0d);
                }
                //textBlock.ReleaseMouseCapture();
            }


        }

     //   EncoderParameters EncParms = new EncoderParameters(1);
        private void textBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            String Y =textBlock.Text;
    
            System.Drawing.Image img = System.Drawing.Image.FromFile(ImgUrl);
     
            System.Drawing.Imaging.PropertyItem[] PropertyItems = img.PropertyItems;
   
         byte[] b  = Encoding.Unicode.GetBytes(Y+'\0');

            PropertyItem propItem36867 = img.GetPropertyItem(0x9C9C);
          
            propItem36867.Value = Encoding.Unicode.GetBytes(Y);
            img.SetPropertyItem(propItem36867);
           
          //  string FilenameTemp = ImgUrl+"a" +".jpg";
          // 

            img.Save(ImgUrl+".temp");
      
            img.Dispose();
            img = null;
            GC.Collect();
            System.IO.File.Delete(ImgUrl);
            System.IO.File.Move(ImgUrl + ".temp",ImgUrl);
        

        }

    }
   
    
}
