using LivePhotoParser.Enums;
using LivePhotoParser.Meizu;
using System.IO;

namespace LivePhotoParser.Test;

public class MeizuParserTests
{
    private readonly LivePhotoParser _parser = new();

    [SetUp]
    public void Setup()
    {
        MeizuLivePhotoParser meizuParser = new();
        LivePhotoParser.RegisterParser(Brand.Meizu, meizuParser);
    }

    [Test]
    public void ParseTest1()
    {
        LivePhoto livePhoto = _parser.Parse(@"C:\Users\HHao\Downloads\P20240624-153054.jpg", Brand.Meizu);
        Console.WriteLine(livePhoto);
        Assert.IsNotNull(livePhoto);
    }

    [Test]
    public void ExtractTest1()
    {
        LivePhoto livePhoto = _parser.Parse(@"C:\Users\HHao\Downloads\P20240624-153054.jpg", Brand.Meizu);
        Console.WriteLine(livePhoto);
        string targetPath = @"C:\Users\HHao\Desktop\meizuTest";
        livePhoto.SaveAllSubFiles(targetPath);
        Assert.True(true);
    }
}