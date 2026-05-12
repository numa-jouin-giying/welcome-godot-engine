using Godot;
using System;
using System.Collections;
using System.Threading.Tasks;

/// <summary>
/// HUDクラス
/// </summary>
public partial class HUD : Control
{
	ProgressBar _progressBar;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_progressBar = GetNodeOrNull<ProgressBar>("PlayerHpBar");
		_progressBar.Value = 100;

		Future.DoAfter(1f, OnAttack_HpBar, 25d).Forget();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	/// <summary>
	/// Tweenサンプルコード
	/// </summary>
	/// <param name="newValue">新しい値</param>
	public void OnAttack_HpBar(double newValue)
	{
		int strength = (int)Mathf.Clamp(Mathf.Abs(newValue - _progressBar.Value)
										, _progressBar.MinValue, _progressBar.MaxValue);
		_progressBar.Value = newValue;

		var origin = _progressBar.Position;
		var tween = CreateTween().SetParallel(true);

		tween.TweenProperty(
			GetNode("PlayerHpBar")
			, "position"
			, _progressBar.Position + Vector2.Left * strength * 0.1f
			, 0.1f)
		.SetTrans(Tween.TransitionType.Elastic);
		// Tweenを連結
		tween.Chain().TweenProperty(
			GetNode("PlayerHpBar")
			, "position"
			, _progressBar.Position + Vector2.Right * strength * 0.1f
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
