using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using LinkBucket.Buckets.Abstractions;
using LinkBucket.SecretVariables;

namespace LinkBucket.Services;

public class BucketService : IBucketService
{
    public async Task<Stream> DownloadAsync(IBucketFile file)
    {
        ArgumentException.ThrowIfNullOrEmpty(file.FileKey, "Argument file key required to download file in bucket");

        using var transferUtility = TransferUtility();
        return await transferUtility.OpenStreamAsync(BucketVariables.BucketName, file.FullName);
    }

    public async Task<string> UploadAsync(Stream stream, IBucketFile file)
    {
        using var transferUtility = TransferUtility();
        stream.Position = 0;

        using var memory = new MemoryStream();
        await stream.CopyToAsync(memory);

        await transferUtility.UploadAsync(new TransferUtilityUploadRequest
        {
            InputStream = memory,
            Key = file.FullName,
            BucketName = BucketVariables.BucketName,
            CannedACL = S3CannedACL.PublicRead
        });

        return file.FileUrl(BucketVariables.BucketName);
    }

    private static TransferUtility TransferUtility()
    {
        return new TransferUtility(BucketVariables.AccessKey, BucketVariables.SecretKey,
            RegionEndpoint.GetBySystemName(BucketVariables.Region));
    }
}