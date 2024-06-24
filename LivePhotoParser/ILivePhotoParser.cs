namespace LivePhotoParser;

public interface ILivePhotoParser
{
    public LivePhoto Parse(string filePath);
}