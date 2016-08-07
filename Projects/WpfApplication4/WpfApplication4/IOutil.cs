using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EXIF文件修改器
{
   static class IOutil
    {


        public static Stream FileToStream(string fileName)
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
        public static byte[] StreamToBytes(Stream stream)
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

         static public BitmapSource GetImage(string address)  
        {  
            return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + string.Format("/Resource/Image/{0}", address), UriKind.Relative));  
        }   

    }
}
