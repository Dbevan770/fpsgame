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
        Vector3 _calculatedMovement = Ctx.CalculateDirectionalMovment(Ctx.WalkSpeed);

        Ctx.AppliedMovementX = _calculatedMovement.x;
        Ctx.AppliedMovementZ = _calculatedMovement.z;
        CheckSwitchStates();
    }

    public override void ExitState() { }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() 
    {
        if (!Ctx.IsMovementPressed)
        {
            SwitchState(Factory.Idle());
        }
        else if(Ctx.IsMovementPressed && Ctx.IsRunPressed)
        {
            SwitchState(Factory.Run());
        }
    }
}
