using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }
    public override void EnterState() 
    {

    }

    public override void UpdateState()
    {
        Ctx.AppliedMovementX = Ctx.CurrentMovementInput.x;
        Ctx.AppliedMovementZ = Ctx.CurrentMovementInput.y;
        CheckSwitchStates();
    }

    public override void ExitState() { }

    public override void InitializeSubState() { }

    public override bool CheckSwitchStates() 
    {
        if (!Ctx.IsMovementPressed)
        {
            SwitchState(Factory.Idle());
            return true;
        }
        else if(Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SwitchState(Factory.Run());
            return true;
        }
        return false;
    }
}