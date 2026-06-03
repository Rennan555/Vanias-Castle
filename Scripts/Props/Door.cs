using Godot;
using System;

public partial class Door : Node2D
{
	[Signal]
	public delegate void SpawnPlayerEventHandler(Node2D player);
	
	[Export]
	private string nextSceneName;
	
	[Export]
	private string nextDoorName;
	private bool isOnDoor = false;
	
	private Node sceneSwitcher;
	
	[Export]
	private Label label;
	private Marker2D spawnMarker;
	private Godot.Node2D player;
	private Node currentScene;
	
	public override void _Ready()
	{
		this.sceneSwitcher = GetTree().CurrentScene;
		this.label = GetNode<Label>("Label");
		this.spawnMarker = GetNode<Marker2D>("SpawnMarker");
		this.currentScene = GetTree().CurrentScene;
	}
	
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("Up") && this.isOnDoor)
		{
			// Inicializa próxima cena e muda
			SetProcess(false);
			
			this.sceneSwitcher.EmitSignal(SceneSwitcher.SignalName.GoToScene, this.nextSceneName, this.nextDoorName, this.player);
		}
	}
	
	public void _BodyEntered(Node2D body)
	{
		if (body is Player)
		{
			this.isOnDoor = true;
			this.label.Visible = true;
			this.player = body;
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
	public void _SpawnPlayer(Node2D player)
	{
		player.GlobalPosition = this.spawnMarker.GlobalPosition;
		GetTree().CurrentScene.AddChild(player);
	}
}
