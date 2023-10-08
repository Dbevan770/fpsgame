using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }
    public override void EnterState() 
    {
        Ctx.AppliedMovementX = 0;
        Ctx.AppliedMovementZ = 0;
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void ExitState() { }

    public override void InitializeSubState() { }

    public override bool CheckSwitchStates() 
    {
        if(Ctx.IsMovementPressed && Ctx.IsRunPressed)
        {
            SwitchState(Factory.Run());
            return true;
        }
        else if(Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SwitchState(Factory.Walk());
            return true;
        }
        return false;
    }
}
