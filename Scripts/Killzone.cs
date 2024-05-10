using Godot;
using System;

public partial class Killzone : Area2D
{
  private void _OnBodyEntered(Node2D body)
  {
    Engine.TimeScale = 0.5f;
    body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
    GetNode<Timer>("Timer").Start();
  }

  private void _OnTimerTimeout()
  {
    Engine.TimeScale = 1f;
    GetTree().ReloadCurrentScene();
  }
}
