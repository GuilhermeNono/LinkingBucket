using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace LinkBucket.LinkedBucket.Abstractions;

public class BucketClientFile
{
    private const int DefaultWidth = 800;
    private const int DefaultHeight = 800;

    private readonly HttpClient _httpClient = new();

    public async Task<Stream> ResizeImageFromUri(Uri destinationUri)
    {
        var outputStream = new MemoryStream();

        var response = await _httpClient.GetStreamAsync(destinationUri);

        var image = await Image.LoadAsync(response);

        var backgroundColor = Color.Transparent;

        var xOffset = (DefaultWidth - image.Width) / 2;
        var yOffset = (DefaultHeight - image.Height) / 2;

        using var canvas = new Image<Rgba32>(DefaultWidth, DefaultHeight, backgroundColor);

        canvas.Mutate(context => { context.DrawImage(image, new Point(xOffset, yOffset), 1f); });

        await canvas.SaveAsJpegAsync(outputStream);

        return outputStream;
    }
}