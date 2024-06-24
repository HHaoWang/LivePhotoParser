using System.Text;
using LivePhotoParser.Enums;
using LivePhotoParser.Utils;

namespace LivePhotoParser;

public class LivePhoto
{
    public required string FilePath { get; init; }
    public required Brand Brand { get; init; }
    public required List<SubFile> SubFiles { get; init; }

    public LivePhoto() { }

    public LivePhoto(string filePath, Brand brand, List<SubFile> subFiles)
    {
        FilePath = filePath;
        Brand = brand;
        SubFiles = subFiles;
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Brand: {Brand}");
        sb.AppendLine($"Location: {FilePath}");
        sb.AppendLine($"Segments ({SubFiles.Count}):");
        foreach (SubFile segment in SubFiles)
        {
            sb.AppendLine(segment.ToString());
        }

        return sb.ToString();
    }

    // ReSharper disable once MemberCanBeProtected.Global
    public virtual Stream ExtractMainPic()
    {
        throw new NotImplementedException();
    }

    public virtual void SaveMainPic(string targetPath)
    {
        Stream mainPic = ExtractMainPic();
        using FileStream fs = new(targetPath, FileMode.Create);
        mainPic.CopyTo(fs);
        fs.Close();
    }

    // ReSharper disable once MemberCanBeProtected.Global
    public virtual Stream ExtractMainVideo()
    {
        throw new NotImplementedException();
    }

    public virtual void SaveMainVideo(string targetPath)
    {
        Stream mainVideo = ExtractMainVideo();
        using FileStream fs = new(targetPath, FileMode.Create);
        mainVideo.CopyTo(fs);
        fs.Close();
    }

    public virtual void SaveAllSubFiles(string targetDir) { }
}