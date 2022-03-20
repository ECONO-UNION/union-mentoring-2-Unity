using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.InputSystem;

public abstract class PlayerAction
{
    protected PlayerComponent component;

    public PlayerAction(PlayerComponent component)
    {
        this.component = component;
    }

    public abstract void OnPressInputHandler();

    public abstract void OnHoldingInputHandler();

    public abstract void OnReleaseInputHandler();

}

public abstract class AxisAction
{
    protected PlayerComponent component;

    public AxisAction(PlayerComponent component)
    {
        this.component = component;
    }

    public abstract void OnEvent(float x, float y);

}

public class AttackAction : PlayerAction
{
    public AttackAction(PlayerComponent component) : base(component)
    {
        this.component = component;
    }

    public override void OnHoldingInputHandler()
    {
        
    }

    public override void OnPressInputHandler()
    {
        
    }

    public override void OnReleaseInputHandler()
    {
        
    }

}

public class JumpAction : PlayerAction
{
    public JumpAction(PlayerComponent component) : base(component)
    {
        this.component = component;
    }

    public override void OnHoldingInputHandler()
    {
        
    }

    public override void OnPressInputHandler()
    {
        
    }

    public override void OnReleaseInputHandler()
    {
        
    }

}

public class WalkAction : AxisAction
{
    float walkSpeed = 5f;

    public WalkAction(PlayerComponent component) : base(component)
    {
        this.component = component;
    }

    public override void OnEvent(float x, float y)
    {
        Vector2 dir = new Vector2(x , y);
        component._rigidbody.MovePosition(component._rigidbody.position + dir * Time.deltaTime * walkSpeed);
    }
   
}