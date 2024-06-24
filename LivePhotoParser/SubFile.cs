using LivePhotoParser.Enums;

namespace LivePhotoParser;

/// <summary>
/// 动态照片中的子文件
/// </summary>
public class SubFile
{
    /// <summary>
    /// 子文件类型
    /// </summary>
    public required SubFileType Type { get; init; }

    /// <summary>
    /// 子文件大小, 单位字节
    /// </summary>
    public required long Size { get; init; }

    public override string ToString()
    {
        return $"Type: {Type}, Size: {Size} Bytes.";
    }
}