using UnityEngine;
public class PlayerFallState : PlayerBaseState, IRootState
{
    public PlayerFallState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {
        IsRootState = true;
        InitializeSubState();
    }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        if(!CheckSwitchStates()) {
            HandleGravity();
        } 
    }

    public override void ExitState() { }

    public void HandleGravity()
    {
        float previousYVelocity = Ctx.CurrentMovementY;
        Ctx.CurrentMovementY = Ctx.CurrentMovementY + Ctx.Gravity * Time.deltaTime;
        Ctx.AppliedMovementY = Mathf.Max((previousYVelocity + Ctx.CurrentMovementY) * 0.5f, -20.0f);
    }

    public override bool CheckSwitchStates()
    {
        if(Ctx.Controller.isGrounded)
        {
            SwitchState(Factory.Grounded());
            return true;
        }
        return false;
    }

    public override void InitializeSubState()
    {
        if (!Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SetSubState(Factory.Idle());
        }
        else if (Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SetSubState(Factory.Walk());
        }
        else
        {
            SetSubState(Factory.Run());
        }
    }
}
