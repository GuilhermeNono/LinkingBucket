using LinkBucket.LinkedBucket.Enum;

namespace LinkBucket.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class LinkAttribute : Attribute
{
    public readonly LinkBucketOptionsEnum BucketOption;

    public LinkAttribute(LinkBucketOptionsEnum toBucket = LinkBucketOptionsEnum.General)
    {
        BucketOption = toBucket;
    }
}