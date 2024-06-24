using LivePhotoParser.Enums;

namespace LivePhotoParser;

/// <summary>
/// 文件段信息
/// </summary>
public class FileSegmentInfo
{
    /// <summary>
    /// 文件段类型
    /// </summary>
    public required SubFileType Type { get; init; }

    /// <summary>
    /// 文件段在文件中的起始位置
    /// </summary>
    public required long StartPosition { get; init; }

    /// <summary>
    /// 文件段在文件中的结束位置
    /// </summary>
    public required long EndPosition { get; init; }

    /// <summary>
    /// 文件段长度
    /// </summary>
    public long Length => EndPosition - StartPosition + 1;
}