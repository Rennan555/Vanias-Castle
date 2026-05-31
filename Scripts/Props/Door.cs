using Godot;
using System;

public partial class Door : Node2D
{
	[Export]
	private string nextDoor;
	private bool isOnDoor = false;
	private Label label;
	
	public override void _Ready()
	{
		this.label = GetNode<Label>("Label");
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
}
