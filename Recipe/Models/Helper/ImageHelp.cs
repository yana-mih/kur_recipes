using System.IO;
using System.Windows.Media.Imaging;

namespace Recipe.Models.Helper;

public static class ImageHelp
{
    private static BitmapImage DisplayImageFromDatabase(byte[] imageBytes)
    {
        var image = ConvertByteArrayToImage(imageBytes);

        if (image != null)
            return image;
        return null;
    }

    public static BitmapImage ConvertByteArrayToImage(byte[] imageBytes)
    {
        if (imageBytes == null || imageBytes.Length == 0) return null;

        var image = new BitmapImage();
        using (var stream = new MemoryStream(imageBytes))
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