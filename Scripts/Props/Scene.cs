using Godot;
using System;

public partial class Scene : Node2D
{
	[Export]
	private string initialDoor = "";
	private Node2D doorsNode;
	private Godot.Collections.Array<Godot.Node> doors;
	
	public void setInitialDoor(string doorName)
	{
		this.initialDoor = doorName;
	}
	
	public override void _Ready()
	{
		this.doorsNode = GetNode<Node2D>("DoorsNode");
		this.doors = doorsNode.GetChildren();
		
		if (this.initialDoor != "")
		{
			// Ativa função de Door para spawnar o player
			GD.Print("Spawnar player");
			
			Door initialDoor = GetNode<Door>("DoorsNode/" + this.initialDoor);
			initialDoor.EmitSignal(Door.SignalName.SpawnPlayer);
		}
	}
	
	public override void _Process(double delta)
	{
		// Sair do jogo
		if (Input.IsActionPressed("Escape")) GetTree().Quit();
	}
}
