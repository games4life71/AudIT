namespace Frontend.Services.AuthentificationServices;

public class ClaimResponse
{
    public string Type { get; set; }
    public string Value { get; set; }

    public ClaimResponse(string type, string value)
    {
        Type = type;
        Value = value;
    }
}