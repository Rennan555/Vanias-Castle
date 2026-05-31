using Godot;
using System;

public partial class Scene : Node2D
{
	public override void _Process(double delta)
	{
		// Sair do jogo
		if (Input.IsActionPressed("Escape")) GetTree().Quit();
	}
}
