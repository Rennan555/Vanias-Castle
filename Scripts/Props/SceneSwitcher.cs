using Godot;
using System;

public partial class SceneSwitcher : Node2D
{
	[Signal]
	public delegate void GoToSceneEventHandler(string nextScene, string nextDoor, Node2D player);
	
	private const string scenesFolder = "Tests";
	
	private Node2D currentSceneNode;
	private Scene currentScene;
	
	private enum scenesEnum
	{
		TestScene1,
		TestScene2,
		TestScene3,
		TestScene4,
	}
	
	private readonly System.Collections.Generic.Dictionary<scenesEnum, string> scenesDictionary = new()
	{
		{ scenesEnum.TestScene1, "res://Scenes/Tests/TestScene1.tscn" },
		{ scenesEnum.TestScene2, "res://Scenes/Tests/TestScene2.tscn" },
		{ scenesEnum.TestScene3, "res://Scenes/Tests/TestScene3.tscn" },
		{ scenesEnum.TestScene4, "res://Scenes/Tests/TestScene4.tscn" },
	};
	
	public override void _Ready()
	{
		this.currentSceneNode = GetNode<Node2D>("CurrentSceneNode");
		PackedScene packedScene = GD.Load<PackedScene>(this.scenesDictionary[scenesEnum.TestScene1]);
		
		PackedScene playerEntity = GD.Load<PackedScene>("res://Entities/Characters/PlayerEntity.tscn");
		Player newPlayer = playerEntity.Instantiate<Player>();
		
		this.currentScene = packedScene.Instantiate<Scene>();
		this.currentScene.setup("Door1", newPlayer);
		this.currentSceneNode.AddChild(this.currentScene);
	}
	
	public override void _Process(double delta)
	{
	}
	
	public void _ChangeScene(string nextScene, string nextDoor, Node2D player)
	{
		if (this.currentScene != null)
		{
			this.currentScene.QueueFree();
			this.currentSceneNode.RemoveChild(currentScene);
		}
		
		PackedScene newScene = GD.Load<PackedScene>($"res://Scenes/{scenesFolder}/{nextScene}.tscn");
		this.currentScene = newScene.Instantiate<Scene>();
		this.currentScene.setup(nextDoor, player);
		
		this.currentSceneNode.AddChild(this.currentScene);
	}
}
