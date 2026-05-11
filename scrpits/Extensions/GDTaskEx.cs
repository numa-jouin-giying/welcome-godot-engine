using System;
using System.Threading.Tasks;
using Godot;

/// <summary>
/// Forgetをコールしたいので実装
/// </summary>
public static class GDTaskEx
{
    public static async void Forget(this Task running)
    {
        try
        {
            await running;
        }
        catch (Exception ex)
        {
            // TODO: 識別できるような一意のIDと一緒にエラーログ出す
            GD.Print(GDLogString.ErrorStr($""));
        }
    }

    public static async void Forget<T>(this Task<T> running)
    {
        try
        {
            await running;
        }
        catch (Exception ex)
        {
            // TODO: 識別できるような一意のIDと一緒にエラーログ出す
            GD.Print(GDLogString.ErrorStr($""));
        }
    }
}