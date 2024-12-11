using LinkBucket.Buckets;
using LinkBucket.Buckets.Abstractions;
using LinkBucket.LinkedBucket.Enum;

namespace LinkBucket.LinkedBucket.Abstractions;

public class BucketOptionSwitch
{
    private IBucketFile? _bucketFile;

    public IBucketFile SyncBucketConfig(LinkBucketOptionsEnum option, string? fileName)
    {
        return _bucketFile = option switch
        {
            LinkBucketOptionsEnum.Person => new PersonMediaBucket(fileName ?? Guid.NewGuid().ToString()),
            LinkBucketOptionsEnum.Product => new ProductMediaBucket(fileName ?? Guid.NewGuid().ToString()),
            LinkBucketOptionsEnum.General => new GeneralMediaBucket(fileName ?? Guid.NewGuid().ToString()),
            LinkBucketOptionsEnum.None => throw new Exception(
                $"Não foi possivel processar o Bucket Option {option.ToString()} "),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}