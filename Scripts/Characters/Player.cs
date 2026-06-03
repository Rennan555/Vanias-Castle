using Godot;
using System;

public partial class Player : Character
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	public byte JumpsLimit { get; set; } = 1;
	public byte currentJumps;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Gravidade
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		} else {
			this.currentJumps = this.JumpsLimit;
		}

		// Pulo
		if (Input.IsActionJustPressed("Jump") && this.currentJumps > 0)
		{
			velocity.Y = JumpVelocity;
			this.currentJumps--;
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
