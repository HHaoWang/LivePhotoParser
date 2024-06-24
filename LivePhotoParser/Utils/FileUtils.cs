using LivePhotoParser.Exceptions;

namespace LivePhotoParser.Utils;

public class FileUtils
{
    /// <summary>
    /// 以二进制形式提取文件片段至新文件中
    /// <para>提取的片段是[startPos,endPos]范围中的（即包括两端）</para>
    /// </summary>
    /// <param name="sourceFile">被提取的文件信息</param>
    /// <param name="startPos">开始提取的位置</param>
    /// <param name="endPos">结束提取的位置</param>
    /// <param name="targetPath">保存位置</param>
    /// <exception cref="Exception"></exception>
    public static void ExtractFile(FileInfo sourceFile, long startPos, long endPos, string targetPath)
    {
        FileStream sourceStream = sourceFile.OpenRead();
        FileStream outputStream = File.Create(targetPath);

        if (endPos > sourceStream.Length)
        {
            endPos = (int)sourceStream.Length;
        }

        byte[] seg = new byte[endPos - startPos + 1];

        sourceStream.Seek(startPos, SeekOrigin.Begin);
        int readLength = sourceStream.Read(seg);
        if (readLength < endPos - startPos + 1)
        {
            throw new FileLoadingException("读取文件失败！文件长度不足！");
        }

        outputStream.Write(seg);

        sourceStream.Close();
        outputStream.Close();
    }

    public static MemoryStream ExtractStream(string sourceFile, long startPos, long endPos)
    {
        FileInfo fileInfo = new(sourceFile);
        using FileStream fileStream = fileInfo.OpenRead();
        fileStream.Seek(startPos, SeekOrigin.Begin);
        MemoryStream memoryStream = new();
        long size = endPos - startPos + 1;
        int bufferSize = 81920 > size ? (int)size : 81920;
        Span<byte> buffer = new byte[bufferSize];
        while (bufferSize != 0)
        {
            if (bufferSize != 81920)
            {
                buffer = new byte[bufferSize];
            }

            int readLength = fileStream.Read(buffer);
            memoryStream.Write(buffer[..readLength]);
            size -= readLength;
            bufferSize = 81920 > size ? (int)size : 81920;
        }

        memoryStream.Seek(0, SeekOrigin.Begin);
        return memoryStream;
    }
}