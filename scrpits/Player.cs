using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] public float Speed = 5f;

	float _direction;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = new Vector2(_direction * Speed, Velocity.Y);
		MoveAndSlide();

		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			var collision = GetSlideCollision(i);
			GD.Print(GDLogString.LOG + "衝突: ", ((Node)collision.GetCollider()).Name);
		}
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
