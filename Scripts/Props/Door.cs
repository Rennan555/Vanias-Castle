using Godot;
using System;

public partial class Door : Node2D
{
	[Signal]
	public delegate void SpawnPlayerEventHandler();
	
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
			// TODO: Impedir que o player precione mais de uma vez para entrar na porta, está bugando
			SetProcess(false);
			
			this.sceneSwitcher.EmitSignal(SceneSwitcher.SignalName.GoToScene, this.nextSceneName, this.nextDoorName);			this.player.QueueFree();
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
	public void _SpawnPlayer()
	{
		PackedScene playerEntity = GD.Load<PackedScene>("res://Entities/Characters/PlayerEntity.tscn");
		Player player = playerEntity.Instantiate<Player>();
		player.GlobalPosition = this.spawnMarker.GlobalPosition;
		GetTree().CurrentScene.AddChild(player);
	}
}
