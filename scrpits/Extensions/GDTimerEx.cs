using System;
using System.Threading.Tasks;
using Godot;

/// <summary>
/// タイマーを使う時の実装
/// </summary>
public static class GDTimerEx
{
    public static async Task CreateGDTimer(this Node owner, double duration, Action callback)
    {
        await owner.ToSignal(owner.GetTree().CreateTimer(duration), SceneTreeTimer.SignalName.Timeout);
        callback.SafeCall();
    }
}