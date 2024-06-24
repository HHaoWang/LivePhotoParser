using LivePhotoParser.Enums;
using LivePhotoParser.Utils;

namespace LivePhotoParser.Meizu;

public class MeizuLivePhoto : LivePhoto
{
    public required List<FileSegmentInfo> Segments { private get; init; }

    public override Stream ExtractMainPic()
    {
        FileSegmentInfo? segment = Segments.Find(s => s.Type == SubFileType.Jpg);
        if (segment is null)
        {
            throw new ArgumentException("Main picture segment not found!");
        }

        return FileUtils.ExtractStream(FilePath, segment.StartPosition, segment.EndPosition);
    }

    public override Stream ExtractMainVideo()
    {
        FileSegmentInfo? segment = Segments.Find(s => s.Type == SubFileType.Mp4);
        if (segment is null)
        {
            throw new ArgumentException("Video segment not found!");
        }

        return FileUtils.ExtractStream(FilePath, segment.StartPosition, segment.EndPosition);
    }

    public override void SaveAllSubFiles(string targetDir)
    {
        DirectoryInfo directory = new(targetDir);
        if (!directory.Exists)
        {
            directory.Create();
        }

        FileInfo sourceFile = new(FilePath);

        int ext = 1;
        foreach (FileSegmentInfo segment in Segments)
        {
            string realPath = Path.GetFileNameWithoutExtension(FilePath) + $"-{ext:00}." + segment.Type;
            realPath = Path.Combine(directory.FullName, realPath);
            ext++;
            FileUtils.ExtractFile(sourceFile, segment.StartPosition, segment.EndPosition, realPath);
        }
    }
}