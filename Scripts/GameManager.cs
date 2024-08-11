using Godot;

public partial class GameManager : Node
{
  private int _Score = 0;
  public void AddPoints(int points)
  {
    _Score += points;
    GetNode<Label>("ScoreLabel").Text = "Coins: " + _Score;
    GD.Print("Score: " + _Score);
  }
}
