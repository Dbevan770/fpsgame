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
        Vector3 _calculatedMovement = Ctx.CalculateDirectionalMovment(Ctx.WalkSpeed * Ctx.RunMultiplier);

        Ctx.AppliedMovementX = _calculatedMovement.x;
        Ctx.AppliedMovementZ = _calculatedMovement.z;

        CheckSwitchStates();
    }

    public override void ExitState() { }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates()
    {
        if (Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SwitchState(Factory.Walk());
        }
        else if (!Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SwitchState(Factory.Idle());
        }
    }
}
