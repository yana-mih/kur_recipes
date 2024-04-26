using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Recipe.Helper;

public class ConvertByteArrayToImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var imageBytes = value as byte[];
        if (imageBytes == null || imageBytes.Length == 0) return null;

        // Преобразование byte[] в BitmapImage
        var bitmapImage = new BitmapImage();
        using (var stream = new MemoryStream(imageBytes))
        {
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
        }

        // Возвращаем BitmapImage
        return bitmapImage;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}