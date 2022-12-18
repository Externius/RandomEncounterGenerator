namespace REG.Core.Abstractions.Settings;

public class CorsSettings
{
    public static readonly string Policy = "default";
    public string[] Urls { get; set; }
}