using System.Text.Json.Serialization;

namespace LinkBucket.Model;

public class GrantTypeObject
{
    public GrantTypeObject(string grantType, string campaign)
    {
        GrantType = grantType;
        Campaign = campaign;
    }

    [JsonPropertyName("grant_type")] public string GrantType { get; set; }

    [JsonPropertyName("campaign_id")] public string Campaign { get; set; }
}