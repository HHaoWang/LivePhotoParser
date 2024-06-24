using LivePhotoParser.Enums;

namespace LivePhotoParser.Utils;

public class JpegParser
{
    public Brand Brand { get; set; }

    public JpegParser(Stream stream)
    {
        if (!stream.CanRead)
        {
            throw new ArgumentException("Stream is not readable.");
        }
    }
}