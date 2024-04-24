using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Recipe.Models.Helper
{
    public static class ImageHelp
    {
        private static BitmapImage DisplayImageFromDatabase(byte[] imageBytes)
        {
            BitmapImage image = ConvertByteArrayToImage(imageBytes);

            if (image != null)
            {
                return image;
            }
            else
            {
                return null;
            }
        }

        public static BitmapImage ConvertByteArrayToImage(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
            {
                return null;
            }

            BitmapImage image = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(imageBytes))
            {
                stream.Position = 0;
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
            }

            return image;
        }
    }
}
