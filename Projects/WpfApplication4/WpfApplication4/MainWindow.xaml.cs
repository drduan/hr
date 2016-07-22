using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Text;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Windows;

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
                fstream = FileToStream(ImgUrl);
                var bitmap = BytesToBitmap(StreamToBytes(fstream));
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
                    System.Drawing.Imaging.PropertyItem[] PropertyItems = img.PropertyItems;
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

        public Stream FileToStream(string fileName)
        {
            // 打开文件  
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            // 读取文件的 byte[]  
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            fileStream.Dispose();
            // 把 byte[] 转换成 Stream  
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
        public byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);

            // 设置当前流的位置为流的开始  
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
        public static Bitmap BytesToBitmap(byte[] Bytes)
        {
            MemoryStream stream = null;
            try
            {
                stream = new MemoryStream(Bytes);
                return new Bitmap((System.Drawing.Image)new Bitmap(stream));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            finally
            {
                stream.Close();
            }


        }


    }
}
