using LinkBucket.Buckets.Abstractions;

namespace LinkBucket.Buckets;

public class GeneralMediaBucket(string fileName) : BucketFile(fileName)
{
    public override string FilePath => "general/media";
}