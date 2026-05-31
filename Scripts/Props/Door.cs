using Godot;
using System;

public partial class Door : Node2D
{
	[Signal]
	public delegate void SpawnPlayerEventHandler();
	
	[Export]
	private string nextDoor;
	private bool isOnDoor = false;
	
	[Export]
	private Label label;
	private Marker2D spawnMarker;
	
	public override void _Ready()
	{
		this.label = GetNode<Label>("Label");
		this.spawnMarker = GetNode<Marker2D>("SpawnMarker");
	}
	
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("Up") && this.isOnDoor)
		{
			
		}
	}
	
	public void _BodyEntered(Node2D body)
	{
		if (body is Player)
		{
			this.isOnDoor = true;
			this.label.Visible = true;
		}
	}
	
	public void _BodyExited(Node2D body)
	{
		if (body is Player)
		{
			this.isOnDoor = false;
			this.label.Visible = false;
		}
	}
	
	// Spawnar player no lugar do marker
	public void _SpawnPlayer()
	{
		PackedScene playerEntity = GD.Load<PackedScene>("res://Entities/Characters/PlayerEntity.tscn");
		Player player = playerEntity.Instantiate<Player>();
		player.GlobalPosition = this.spawnMarker.GlobalPosition;
		GetTree().CurrentScene.AddChild(player);
	}
}
