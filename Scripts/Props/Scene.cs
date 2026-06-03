using Godot;
using System;

public partial class Scene : Node2D
{
	[Export]
	private string initialDoor = "";
	private Node2D doorsNode;
	private Godot.Collections.Array<Godot.Node> doors;
	private Node2D currentPlayer;
	
	public void setup(string doorName, Node2D player)
	{
		this.initialDoor = doorName;
		this.currentPlayer = player;
	}
	
	public override void _Ready()
	{
		this.doorsNode = GetNode<Node2D>("DoorsNode");
		this.doors = doorsNode.GetChildren();
		
		if (this.initialDoor != "")
		{
			// Ativa função de Door para spawnar o player
			Door initialDoor = GetNode<Door>("DoorsNode/" + this.initialDoor);
			initialDoor.EmitSignal(Door.SignalName.SpawnPlayer, this.currentPlayer);
		}
	}
	
	public override void _Process(double delta)
	{
		// Sair do jogo
		if (Input.IsActionPressed("Escape")) GetTree().Quit();
	}
}
