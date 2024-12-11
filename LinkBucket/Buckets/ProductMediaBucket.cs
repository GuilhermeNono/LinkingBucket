using LinkBucket.Buckets.Abstractions;

namespace LinkBucket.Buckets;

public class ProductMediaBucket(string fileName) : BucketFile(fileName)
{
    public override string FilePath => "products/image";
}