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
}
