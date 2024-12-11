using LinkBucket.Buckets.Abstractions;
using LinkBucket.LinkedBucket.Abstractions;
using LinkBucket.LinkedBucket.Enum;
using LinkBucket.Services;

namespace LinkBucket.LinkedBucket;

public class LinkBucket
{
    private readonly BucketOptionSwitch _bucketSync = new();

    private readonly HttpClient _client = new();
    private readonly BucketClientFile _clientFile = new();
    private readonly BucketService _service = new();

    public readonly string? FileName;

    private IBucketFile? _bucketFile;
    public required LinkBucketOptionsEnum BucketOption = LinkBucketOptionsEnum.None;
    public required Uri DestinationUri;

    public LinkBucket(LinkBucketOptionsEnum bucketOption, Uri uri, string? fileName = null) :
        this()
    {
        BucketOption = bucketOption;
        DestinationUri = uri;
        FileName = fileName;
    }

    public LinkBucket()
    {
    }

    public async Task<string?> GetInternalS3LinkAsync()
    {
        try
        {
            _bucketFile = _bucketSync.SyncBucketConfig(BucketOption, FileName);

            var outputStream = await _clientFile.ResizeImageFromUri(DestinationUri);

            if (_bucketFile is null)
                throw new Exception("Não foi encontrado nem um Bucket para alocar o arquivo desse link");

            return await _service.UploadAsync(outputStream, _bucketFile);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}