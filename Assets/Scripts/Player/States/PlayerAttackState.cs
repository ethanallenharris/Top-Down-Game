using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{

    public PlayerAttackState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }


    public override void EnterState() {
        //Cloud poof at feet and step sound
    }

    public override void UpdateState() {
        //Add take damage here:
        _currentContext.DetectDash();
    }

    public override void ExitState() { }

    public override void InitialiseSubState() { }

    public override void CheckSwitchState() { }
}
