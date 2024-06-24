namespace LivePhotoParser.Exceptions;

public class FileLoadingException : Exception
{
    public FileLoadingException(string message) : base(message) { }
}