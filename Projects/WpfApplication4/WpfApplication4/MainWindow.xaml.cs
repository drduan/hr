using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Text;
using ExifWorks;

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
                //此处做你想做的事 ...=ofd.FileName; 

                //MessageBox.Show("" + ofd.FileName);
                this.ImgUrl = ofd.FileName;


                ImageBrush ib = new ImageBrush();
                //ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/image1.jpg"));
                ib.ImageSource = new BitmapImage(new Uri(ImgUrl));
                //ib.ImageSource = @".\images\image1.jpg";
                //ib.SetCurrentValue();
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
                    //System.Text.Encoding ascii = System.Text.Encoding.ASCII; ascii.GetString(@coxp);// pi是exif的属性

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
        public System.IO.Stream FileToStream(string fileName)
        {
            // 打开文件  
            System.IO.FileStream fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            // 读取文件的 byte[]  
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            // 把 byte[] 转换成 Stream  
            System.IO.Stream stream = new System.IO.MemoryStream(bytes);
            return stream;
        }

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

        private void textBlock_TextChanged(object sender, TextChangedEventArgs e)
        {

            new ExifManager(ImgUrl).SetPropertyString((int)ExifManager.TagNames.XPComment,textBlock.Text);
            //System.Text.Encoding ascii = System.Text.Encoding.ASCII; ascii.GetString(@coxp);// pi是exif的属性

            string asdas = textBlock.Text;
  

            //写入exif信息
        }
    }
}
