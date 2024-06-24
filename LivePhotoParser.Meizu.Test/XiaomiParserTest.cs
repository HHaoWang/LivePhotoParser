using LivePhotoParser.Enums;
using LivePhotoParser.Meizu;
using LivePhotoParser.Xiaomi;

namespace LivePhotoParser.Test;

public class XiaomiParserTest
{
    private readonly LivePhotoParser _parser = new();

    [SetUp]
    public void Setup()
    {
        XiaomiLivePhotoParser xiaomiParser = new();
        LivePhotoParser.RegisterParser(Brand.Xiaomi, xiaomiParser);
    }

    [Test]
    public void ParseTest1()
    {
        LivePhoto livePhoto =
            _parser.Parse(@"C:\Users\HHao\Desktop\30F95926A5C317DA46AAA12B246AD99E.jpg", Brand.Xiaomi);
        Console.WriteLine(livePhoto);
        Assert.IsNotNull(livePhoto);
    }

    [Test]
    public void ExtractTest1()
    {
        LivePhoto livePhoto =
            _parser.Parse(@"C:\Users\HHao\Desktop\30F95926A5C317DA46AAA12B246AD99E.jpg", Brand.Xiaomi);
        Console.WriteLine(livePhoto);
        string targetPath = @"C:\Users\HHao\Desktop\xiaomiTest";
        livePhoto.SaveAllSubFiles(targetPath);
        Assert.True(true);
    }
}