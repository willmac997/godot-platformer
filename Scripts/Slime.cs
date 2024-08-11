using Godot;

public partial class Slime : Node2D
{
  [Export]
  private const float _Speed = 45.0f;
  private Vector2 _Velocity = new Vector2(0f, 0f);
  private int _Direction = 1;

  private AnimatedSprite2D _AnimatedSprite2D;
  private RayCast2D _RayCastRight;
  private RayCast2D _RayCastLeft;

  public override void _Ready()
  {
    _RayCastLeft = GetNode<RayCast2D>("RayCastLeft");
    _RayCastRight = GetNode<RayCast2D>("RayCastRight");
    _AnimatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
    GD.Print(_RayCastLeft);
    if (_RayCastLeft.IsColliding()) _Direction = 1;
    if (_RayCastRight.IsColliding()) _Direction = -1;
    _AnimatedSprite2D.FlipH = _Direction == 1 ? false : true;

    _Velocity.X = _Speed;
    Position += _Direction * _Velocity * (float)delta;
  }
}
