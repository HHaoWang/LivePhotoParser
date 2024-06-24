# LivePhotoParser
A C#/.Net library that can parse live photos from various smartphone brands.

һ�����Խ�������Ʒ���ֻ������ʵ����Ƭ����̬��Ƭ��Live Photo����C#/.Net�⡣

## Supported Brands
- Meizu
- Xiaomi

## Usage
General usage:
```csharp
using LivePhotoParser;

// register parsers. This step is required cause the library doesn't know specific parsers by default.
MeizuLivePhotoParser meizuParser = new();
XiaomiLivePhotoParser xiaomiParser = new();
LivePhotoParser.RegisterParser(Brand.Meizu, meizuParser);
LivePhotoParser.RegisterParser(Brand.Xiaomi, xiaomiParser);

LivePhotoParser parser = new();
// auto detect brand
LivePhoto livePhoto = parser.Parse("path/to/live/photo");
// specify brand
// LivePhoto livePhoto = parser.Parse("path/to/live/photo", Brand.Xiaomi);

// infos
Console.WriteLine(livePhoto.Brand);
List<SubFile> subFiles = livePhoto.SubFiles;
Console.WriteLine(livePhoto);

// get photo and video streams
MemoryStream photoStream = livePhoto.ExtractMainPic();
MemoryStream videoStream = livePhoto.ExtractMainVideo();

// save to file
livePhoto.SaveMainPic("path/to/save/photo.jpg");
livePhoto.SaveMainVideo("path/to/save/video.mp4");
livePhoto.SaveAllSubFiles("path/to/save/subfiles/directory");
```

Specific usage:
```csharp
using LivePhotoParser.Meizu;

MeizuLivePhotoParser parser = new();
// ILivePhotoParser parser = new MeizuLivePhotoParser();
MeizuLivePhoto livePhoto = parser.Parse("path/to/live/photo");
LivePhoto aLivePhoto = livePhoto;
```

## License

This project is licensed under the LGPL v3 License - see the [LICENSE](LICENSE.txt) file for details.
