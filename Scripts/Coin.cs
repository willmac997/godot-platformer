using Godot;
using System;

public partial class Coin : Area2D
{
  private void _OnBodyEntered(Node2D body)
  {
    if (GetNodeOrNull("%GameManager") is GameManager gameManager) gameManager.AddPoints(1);
    GetNode<AnimationPlayer>("AnimationPlayer").Play("Pickup");
    GD.Print("Coin collected!");
  }
}
