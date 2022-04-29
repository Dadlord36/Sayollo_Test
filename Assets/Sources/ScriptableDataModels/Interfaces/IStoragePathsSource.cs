using Structures;

namespace ScriptableDataModels.Interfaces
{
    public interface IStoragePathsSource
    {
        FileData VideoFileData { get; }
        string VideoFileFullPath { get; }
    }
}