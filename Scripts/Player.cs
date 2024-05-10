using Godot;
using System;

public partial class Player : CharacterBody2D
{
  public const float Speed = 130.0f;
  public const float JumpVelocity = -300.0f;
  private AnimatedSprite2D _Sprite;

  // Get the gravity from the project settings to be synced with RigidBody nodes.
  public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

  public override void _Ready()
  {
    _Sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
  }

  public override void _PhysicsProcess(double delta)
  {
    Vector2 velocity = Velocity;

    // Add the gravity.
    if (!IsOnFloor())
      velocity.Y += gravity * (float)delta;

    // Handle Jump.
    if (Input.IsActionJustPressed("Jump") && IsOnFloor())
      velocity.Y = JumpVelocity;

    // Get the input direction and handle the movement/deceleration.
    // As good practice, you should replace UI actions with custom gameplay actions.
    Vector2 direction = Input.GetVector("MoveLeft", "MoveRight", "ui_up", "ui_down");
    if (direction != Vector2.Zero)
    {
      _Sprite.FlipH = direction.X < 0;
      velocity.X = direction.X * Speed;
    }
    else
    {
      velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
    }

    // Handle animations
    if (IsOnFloor())
    {
      if (direction != Vector2.Zero)
      {
        _Sprite.Play("Run");
      }
      else
      {
        _Sprite.Play("Idle");
      }
    }
    else
    {
      _Sprite.Play("Jump");
    }

    Velocity = velocity;
    MoveAndSlide();
  }
}
