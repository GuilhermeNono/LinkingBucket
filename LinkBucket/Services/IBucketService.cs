using LinkBucket.Buckets.Abstractions;

namespace LinkBucket.Services;

public interface IBucketService
{
    public Task<Stream> DownloadAsync(IBucketFile file);
    public Task<string> UploadAsync(Stream stream, IBucketFile file);
}