using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace Recipe.Helper
{
    public static class ImgHelper
    {
        public static byte[] ImageToByteArray(string imagePath)
        {
            byte[] byteArray = null;

            using (Image image = Image.FromFile(imagePath))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    image.Save(stream, image.RawFormat);
                    byteArray = stream.ToArray();
                }
            }

            return byteArray;
        }

        public static BitmapImage ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                return null;
            }

            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
            }

            return bitmapImage;
        }
    }
}
