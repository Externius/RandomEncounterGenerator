namespace REG.Core.Abstractions.Settings;

public class CorsSettings
{
    public const string Policy = "default";
    public string[] Urls { get; set; }
}