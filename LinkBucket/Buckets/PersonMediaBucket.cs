using LinkBucket.Buckets.Abstractions;

namespace LinkBucket.Buckets;

public class PersonMediaBucket(string fileName) : BucketFile(fileName)
{
    public override string FilePath => "people/medias/image";
}