using Godot;

public partial class Killzone : Area2D
{

  private void _OnBodyEntered(Node2D body)
  {
    Engine.TimeScale = 0.5f;
    if (body.HasMethod("OnHurt"))
    {
      body.Call("OnHurt");
    }
    GetNode<Timer>("Timer").Start();
  }

  private void _OnTimerTimeout()
  {
    Engine.TimeScale = 1f;
    GetTree().ReloadCurrentScene();
  }
}
