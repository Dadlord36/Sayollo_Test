using ScriptableDataModels.Interfaces;
using Structures;
using UnityEngine;

namespace ScriptableDataModels
{
    [CreateAssetMenu(fileName = nameof(StoragePathsSource), menuName = nameof(ScriptableDataModels) + "/" + nameof(StoragePathsSource), order = 0)]
    public class StoragePathsSource : ScriptableObject, IStoragePathsSource
    {
        [SerializeField] private FileData videoFileData;
        public FileData VideoFileData => videoFileData;

        public string VideoFileFullPath => Utilities.FileDataExtension.GetAppDataStorageRelativeFilePath(videoFileData);
    }
}