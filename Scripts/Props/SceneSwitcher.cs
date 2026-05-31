using Godot;
using System;

public partial class SceneSwitcher : Node2D
{
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
		PackedScene packedScene = GD.Load<PackedScene>(this.scenesDictionary[scenesEnum.TestScene]);
		this.currentScene = packedScene.Instantiate<Scene>();
		this.currentScene.setInitialDoor("Door1");
		AddChild(this.currentScene);
	}
	
	public override void _Process(double delta)
	{
	}
}
