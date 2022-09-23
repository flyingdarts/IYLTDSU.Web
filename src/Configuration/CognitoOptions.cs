namespace IYLTDSU.WebApp.Configuration;

public class CognitoOptions
{

    public const string Cognito = "CognitoOptions";
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string GrantType { get; set; } = string.Empty;
    public string RedirectUri { get; set; } = string.Empty;
    public string MetaDataAddress { get; set; } = string.Empty;
    public string LogOutUri { get; set; } = string.Empty;

    public List<KeyValuePair<string, string>> ToKeyValuePairs()
    {
        return new List<KeyValuePair<string, string>>
        {
            new("client_id", ClientId),
            new("client_secret", ClientSecret),
            new("grant_type", GrantType),
            new("redirect_uri", RedirectUri)
        };
    }
}
