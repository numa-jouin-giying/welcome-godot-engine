using Godot;
using System;

public partial class Player : Sprite2D
{
	[Export] public float Speed = 5f;

	float _direction;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += new Vector2(_direction, Position.Y) * Speed;
	}

	/// <summary>
	/// 入力ハンドリングサンプル
	/// </summary>
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("right"))
		{
			_direction = 1;
		}

		if (@event.IsActionPressed("left"))
		{
			_direction = -1;
		}

		if (@event.IsActionReleased("right") || @event.IsActionReleased("left"))
		{
			_direction = 0;
		}
	}
}
