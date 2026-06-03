using Godot;
using System;

public partial class DoubleJumpItem : Item
{
	public override void applyUpgrade(Player player)
	{
		if (player is Player) player.JumpsLimit = 2;
	}
	
	public override void _Ready()
	{
	}
	
	public override void _Process(double delta)
	{
	}
}
