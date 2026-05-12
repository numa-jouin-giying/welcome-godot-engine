using System;
using System.Threading.Tasks;

/// <summary>
/// Task関連の拡張実装
/// </summary>
public static partial class Future
{
    /// <summary>
    /// 遅延後にコールバック実行
    /// </summary>
    /// <param name="sec">秒</param>
    /// <param name="callback">コールバック</param>
    /// <returns>Task</returns>
    public static async Task DoAfter(float sec, Action callback)
    {
        await Task.Delay((int)(sec * 1000f));
        callback.SafeCall();
    }

    /// <summary>
    /// 遅延後にコールバック実行
    /// </summary>
    /// <typeparam name="T">コールバックへのパラメータの型</typeparam>
    /// <param name="sec">秒</param>
    /// <param name="callback">コールバック</param>
    /// <param name="param">コールバックへのパラメータ</param>
    /// <returns>Task</returns>
    public static async Task DoAfter<T>(float sec, Action<T> callback, T param)
    {
        await Task.Delay((int)(sec * 1000f));
        callback.SafeCall(param);
    }

    /// <summary>
    /// 遅延後にコールバック実行
    /// </summary>
    /// <param name="millsec">ミリ秒</param>
    /// <param name="callback">コールバック</param>
    /// <returns>Task</returns>
    public static async Task DoAfter(int millsec, Action callback)
    {
        await Task.Delay(millsec);
        callback.SafeCall();
    }

    /// <summary>
    /// 遅延後にコールバック実行
    /// </summary>
    /// <typeparam name="T">コールバックのパラメータの型</typeparam>
    /// <param name="millsec">ミリ秒</param>
    /// <param name="callback">コールバック</param>
    /// <param name="param">コールバックのパラメータ</param>
    /// <returns>Task</returns>
    public static async Task DoAfter<T>(int millsec, Action<T> callback, T param)
    {
        await Task.Delay(millsec);
        callback.SafeCall(param);
    }

    /// <summary>
    /// Taskの実行後にコールバックを連結してコールする
    /// </summary>
    /// <param name="running">連結元Task</param>
    /// <param name="callback">Task実行後のコールバック</param>
    /// <returns>Task</returns>
    public static async Task FollowWith(this Task running, Action callback)
    {
        await running;
        callback.SafeCall();
    }

    /// <summary>
    /// Taskの実行後にコールバックを連結してコールする
    /// </summary>
    /// <typeparam name="T">Task実行後のコールバックのパラメータの型</typeparam>
    /// <param name="running">連結元Task</param>
    /// <param name="callback">Task実行後のコールバック</param>
    /// <param name="param">Task実行後のコールバックのパラメータ</param>
    /// <returns>Task</returns>
    public static async Task FollowWith<T>(this Task running, Action<T> callback, T param)
    {
        await running;
        callback.SafeCall(param);
    }
}