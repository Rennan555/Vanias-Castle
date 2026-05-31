using Godot;
using System;

public partial class SceneSwitcher : Node2D
{
	[Signal]
	public delegate void GoToSceneEventHandler(string nextScene, string nextDoor);
	
	private Node2D currentSceneNode;
	private Scene currentScene;
	
	private enum scenesEnum
	{
		TestScene,
	}
	
	private readonly System.Collections.Generic.Dictionary<scenesEnum, string> scenesDictionary = new()
	{
		{ scenesEnum.TestScene, "res://Scenes/TestScene.tscn" }
	};
	
	public override void _Ready()
	{
		this.currentSceneNode = GetNode<Node2D>("CurrentSceneNode");
		PackedScene packedScene = GD.Load<PackedScene>(this.scenesDictionary[scenesEnum.TestScene]);
		this.currentScene = packedScene.Instantiate<Scene>();
		this.currentScene.setInitialDoor("Door1");
		this.currentSceneNode.AddChild(this.currentScene);
	}
	
	public override void _Process(double delta)
	{
	}
	
	public void _ChangeScene(string nextScene, string nextDoor)
	{
		if (this.currentScene != null)
		{
			this.currentScene.QueueFree();
			this.currentSceneNode.RemoveChild(currentScene);
		}
		
		PackedScene newScene = GD.Load<PackedScene>($"res://Scenes/{nextScene}.tscn");
		this.currentScene = newScene.Instantiate<Scene>();
		this.currentScene.setInitialDoor(nextDoor);
		
		this.currentSceneNode.AddChild(this.currentScene);
	}
}
