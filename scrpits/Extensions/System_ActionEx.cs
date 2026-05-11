using System;

/// <summary>
/// Action拡張実装
/// </summary>
public static class System_ActionEx
{
    /// <summary>
    /// 内部でNULLチェックを実行
    /// </summary>
    /// <param name="action">実行するデリゲート</param>
    /// <returns>NULLでないならTrue</returns>
    public static bool SafeCall(this Action action)
    {
        if (action is null) return false;

        action.Invoke();
        return true;
    }
}