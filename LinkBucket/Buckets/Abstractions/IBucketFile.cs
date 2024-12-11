namespace LinkBucket.Buckets.Abstractions;

public interface IBucketFile
{
    public string FilePath { get; }
    public string FileKey { get; }
    public string FullName { get; }
    public string FileUrl(string bucketName);
}