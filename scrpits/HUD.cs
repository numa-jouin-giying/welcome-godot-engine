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

		Future.DoAfter(1f, OnAttack).Forget();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	/// <summary>
	/// Tweenサンプルコード＆攻撃をされた時の実装
	/// </summary>
	public void OnAttack()
	{
		var origin = _progressBar.Position;
		var tween = CreateTween().SetParallel(true);
		// 押される。以下ふたつは並列
		tween
		.TweenProperty(GetNode("PlayerHpBar")
			, "position"
			, _progressBar.Position + Vector2.Down * 25
			, 0.1f)
		.SetEase(Tween.EaseType.InOut)
		.SetTrans(Tween.TransitionType.Elastic);
		tween
		.TweenProperty(GetNode("PlayerHpBar")
			, "scale"
			, new Vector2(0.9f, 0.9f)
			, 0.1f)
		.SetEase(Tween.EaseType.InOut)
		.SetTrans(Tween.TransitionType.Elastic);

		// 戻る。上の後にチェインする並列なTweenふたつ
		tween.Chain()
			.TweenProperty(GetNode("PlayerHpBar")
			, "position"
			, origin
			, 0.1f)
		.SetEase(Tween.EaseType.InOut)
		.SetTrans(Tween.TransitionType.Elastic);
		tween
		.TweenProperty(GetNode("PlayerHpBar")
			, "scale"
			, Vector2.One
			, 0.1f)
		.SetEase(Tween.EaseType.InOut)
		.SetTrans(Tween.TransitionType.Elastic);
	}
}
