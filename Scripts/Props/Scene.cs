using Godot;
using System;

public partial class Scene : Node2D
{
	private Node2D doorsNode;
	private Godot.Collections.Array<Godot.Node> doors;
	
	public override void _Ready()
	{
		this.doorsNode = GetNode<Node2D>("DoorsNode");
		this.doors = doorsNode.GetChildren();
	}
	
	public override void _Process(double delta)
	{
		// Sair do jogo
		if (Input.IsActionPressed("Escape")) GetTree().Quit();
	}
}
