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
        await running;
    }

    public static async void Forget<T>(this Task<T> running)
    {
        await running;
    }
}