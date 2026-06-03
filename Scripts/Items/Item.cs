using Godot;
using System;

public partial class Item : Node2D
{
	private Area2D CollectArea;
	
	public override void _Ready()
	{
		this.CollectArea = GetNode<Area2D>("CollisionArea");
	}
	
	public void _BodyEntered(Node2D body)
	{
		if (body is Player)
		{
			// função de atualizar upgrade
			QueueFree();
		}
	}
}
