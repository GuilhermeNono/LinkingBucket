namespace LinkBucket.Buckets.Abstractions;

public abstract class BucketFile(string fileName) : IBucketFile
{
    public string FileKey { get; } = Guid.NewGuid() + Path.GetExtension(fileName);

    public abstract string FilePath { get; }

    public string FullName => FilePath + "/" + FileKey;

    public string FileUrl(string bucketName)
    {
        return $"https://s3.amazonaws.com/{bucketName}/{FullName}";
    }
}