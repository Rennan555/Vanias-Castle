using Godot;
using System;

public abstract partial class Item : Node2D
{
	private Area2D CollectArea;
	
	public override void _Ready()
	{
		this.CollectArea = GetNode<Area2D>("CollisionArea");
	}
	
	public abstract void applyUpgrade(Player player);
	
	public void _BodyEntered(Node2D body)
	{
		if (body is Player)
		{
			this.applyUpgrade(body as Player);
			QueueFree();
		}
	}
}
