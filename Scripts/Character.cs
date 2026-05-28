using Godot;
using System;

public partial class Character : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Gravidade
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Pulo
		if (Input.IsActionJustPressed("Jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Movimentacao
		Vector2 direction = Input.GetVector("Left", "Right", "Up", "Down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
