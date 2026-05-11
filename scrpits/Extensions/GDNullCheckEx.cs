using Godot;

/// <summary>
/// NULLチェック用実装
/// </summary>
public static class GDNullCheckEx
{
    public static bool isValid(this Node n)
    {
        return n is not null;
    }
}