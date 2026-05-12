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

    /// <summary>
    /// 内部でNULLチェックを実行
    /// </summary>
    /// <typeparam name="T">デリゲートへのパラメータの型</typeparam>
    /// <param name="action">実行するデリゲート</param>
    /// <param name="param">デリゲートへのパラメータ</param>
    /// <returns>安全に実行できたか</returns>
    public static bool SafeCall<T>(this Action<T> action, T param)
    {
        if (action is null) return false;

        action.Invoke(param);
        return true;
    }
}