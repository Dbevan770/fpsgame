using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }
    public override void EnterState() 
    {
        
    }

    public override void UpdateState()
    {
        if(!CheckSwitchStates())
        {
            Ctx.AppliedMovementX = Ctx.CurrentMovementInput.x * Ctx.RunMultiplier;
            Ctx.AppliedMovementZ = Ctx.CurrentMovementInput.y * Ctx.RunMultiplier;
        }
    }

    public override void ExitState() { }

    public override void InitializeSubState() { }

    public override bool CheckSwitchStates()
    {
        if (Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SwitchState(Factory.Walk());
            return true;
        }
        else if (!Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SwitchState(Factory.Idle());
            return true;
        }
        return false;
    }
}
