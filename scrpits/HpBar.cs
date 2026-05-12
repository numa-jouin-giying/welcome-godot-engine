using Godot;
using System;
using System.Collections;
using System.Threading.Tasks;

/// <summary>
/// HUDクラス
/// </summary>
public partial class HpBar : ProgressBar
{
	[Export] public int Min { get; set; } = 1;
	[Export] public int Max { get; set; } = 100;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MinValue = Min;
		Value = MaxValue = Max;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	/// <summary>
	/// Tweenサンプルコード
	/// </summary>
	/// <param name="newValue">新しい値</param>
	public void OnAttack(double newValue)
	{
		int strength = (int)Mathf.Clamp(Mathf.Abs(newValue - Value)
										, MinValue, MaxValue);
		Value = newValue;

		var origin = Position;
		var tween = CreateTween().SetParallel(true);

		tween.TweenProperty(
			GetNode("PlayerHpBar")
			, "position"
			, Position + Vector2.Left * strength * 0.1f
			, 0.1f)
		.SetTrans(Tween.TransitionType.Elastic);
		// Tweenを連結
		tween.Chain().TweenProperty(
			GetNode("PlayerHpBar")
			, "position"
			, Position + Vector2.Right * strength * 0.1f
			, 0.1f)
		.SetTrans(Tween.TransitionType.Elastic);
		// 最終的に元のPosに戻る
		tween.Chain().TweenProperty(
			GetNode("PlayerHpBar")
			, "position"
			, origin
			, 0.1f)
		.SetTrans(Tween.TransitionType.Elastic);
	}
}
