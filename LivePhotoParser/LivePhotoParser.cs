using LivePhotoParser.Enums;

namespace LivePhotoParser;

public class LivePhotoParser : ILivePhotoParser
{
    private static readonly Dictionary<Brand, ILivePhotoParser> Parsers = new();

    public static void RegisterParser(Brand brand, ILivePhotoParser parser)
    {
        Parsers[brand] = parser;
    }

    public static void UnregisterParser(Brand brand)
    {
        Parsers.Remove(brand);
    }

    public LivePhoto Parse(string filePath)
    {
        throw new NotImplementedException();
    }

    public LivePhoto Parse(string filePath, Brand brand)
    {
        if (!Parsers.TryGetValue(brand, out ILivePhotoParser? parser))
        {
            throw new ArgumentException(
                "Parser for the specified brand is not registered. Please register the specified brand live photo parser before using!");
        }

        return parser.Parse(filePath);
    }
}