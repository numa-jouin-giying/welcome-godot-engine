using Godot;
using System;
using System.Collections;
using System.Threading.Tasks;

/// <summary>
/// HUDクラス
/// </summary>
public partial class HUD : Control
{
	HpBar _hp;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_hp = GetNodeOrNull<HpBar>("PlayerHpBar");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
