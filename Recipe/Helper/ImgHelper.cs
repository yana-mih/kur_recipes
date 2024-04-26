using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace Recipe.Helper;

public static class ImgHelper
{
    public static byte[] ImageToByteArray(string imagePath)
    {
        byte[] byteArray = null;

        using (var image = Image.FromFile(imagePath))
        {
            using (var stream = new MemoryStream())
            {
                image.Save(stream, image.RawFormat);
                byteArray = stream.ToArray();
            }
        }

        return byteArray;
    }

    public static BitmapImage ByteArrayToImage(byte[] byteArray)
    {
        if (byteArray == null || byteArray.Length == 0) return null;

        var bitmapImage = new BitmapImage();
        using (var stream = new MemoryStream(byteArray))
        {
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
        }

        return bitmapImage;
    }
}