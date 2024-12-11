using System.Collections.Frozen;

namespace LinkBucket;

public static class CorruptionStringConstant
{
    public const string CorruptionString = "Ã\u0083";

    public static readonly FrozenDictionary<int, char> Windows1252Characters = new Dictionary<int, char>
    {
        { 130, '‚' },
        { 131, 'ƒ' },
        { 132, '„' },
        { 133, '…' },
        { 134, '†' },
        { 135, '‡' },
        { 136, 'ˆ' },
        { 137, '‰' },
        { 138, 'Š' },
        { 139, '‹' },
        { 140, 'Œ' },
        { 145, '‘' },
        { 146, '’' },
        { 147, '“' },
        { 148, '”' },
        { 149, '•' },
        { 150, '–' },
        { 151, '—' },
        { 152, '˜' },
        { 153, '™' },
        { 154, 'š' },
        { 155, '›' },
        { 156, 'œ' },
        { 159, 'Ÿ' },
        { 173, '-' }
    }.ToFrozenDictionary();

    public static readonly FrozenDictionary<string, char> HtmlCodes = new Dictionary<string, char>()
    {
        { "&amp;", '&' },
        { "&quot;", '"' }
    }.ToFrozenDictionary();
}