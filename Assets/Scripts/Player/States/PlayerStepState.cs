using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStepState : PlayerBaseState
{

    public PlayerStepState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }


    public override void EnterState() {
        //Cloud poof at feet and step sound
    }

    public override void UpdateState() {
        //Add take damage here:
    }

    public override void ExitState() { }

    public override void InitialiseSubState() { }

    public override void CheckSwitchState() { }
}
