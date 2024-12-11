using System.Text;

namespace LinkBucket.Converters;

public class StringConverter
{
    private string _value;
    private static bool NeedsADoubleDecoding(string value) => value.Contains(CorruptionStringConstant.CorruptionString);

    private StringConverter(string value)
    {
        _value = value;
    }

    public string Value { get => _value; set => _value = value; }

    private static string EncodeUtf8(string value)
    {
        
        if (NeedsADoubleDecoding(value))
            Decode(value, out value);

        Decode(value, out value);
        ConvertFromWindowsToUnicode(value, out value);

        ReplaceHtmlCode(value, out value);

        return value;
    }

    private static void ConvertFromWindowsToUnicode(string txt, out string value)
    {
        if (string.IsNullOrEmpty(txt))
        {
            value = txt;
            return;
        }

        var sb = new StringBuilder();
        foreach (var c in txt)
        {
            var i = (int)c;

            if (i is >= 130 and <= 173 &&
                CorruptionStringConstant.Windows1252Characters.TryGetValue(i, out var mappedChar))
            {
                sb.Append(mappedChar);
                continue;
            }

            sb.Append(c);
        }

        value = sb.ToString();
    }

    private static void Decode(string value, out string decodedValue)
    {
        byte[] isoBytes = Encoding.Latin1.GetBytes(value);
        decodedValue = Encoding.UTF8.GetString(isoBytes);
    }

    private static void ReplaceHtmlCode(string value, out string decodedValue)
    {
        while (HasHtmlCodeInString(value, out var codes))
            foreach (var (code, replacement) in codes)
                value = value.Replace(code, replacement.ToString());

        decodedValue = value;
    }

    private static bool HasHtmlCodeInString(string str, out Dictionary<string, char> codes)
    {
        codes = [];
        bool hasCode = false;

        foreach (var (code, value) in CorruptionStringConstant.HtmlCodes)
        {
            if (!str.Contains(code)) continue;

            codes.Add(code, value);
            hasCode = true;
        }

        return hasCode;
    }

    public static implicit operator string(StringConverter converter)
    {
        return converter.Value;
    }

    public static implicit operator StringConverter(string value)
    {
        return new StringConverter(EncodeUtf8(value));
    }
}
