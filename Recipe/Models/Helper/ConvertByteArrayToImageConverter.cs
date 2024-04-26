using System.Globalization;
using System.Windows.Data;

namespace Recipe.Models.Helper;

public class ConvertByteArrayToImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var imageBytes = value as byte[];
        if (imageBytes == null || imageBytes.Length == 0) return null;

        return ImageHelp.ConvertByteArrayToImage(imageBytes);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}