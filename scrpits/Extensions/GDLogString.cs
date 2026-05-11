/// <summary>
/// Logger関連の実装
/// </summary>
public static class GDLogString
{
    public const string LOG = "[log]:";
    public const string ERROR = "[Error]:";

    public static string ErrorStr(string msg)
    {
        return $"{ERROR}msg";
    }
}