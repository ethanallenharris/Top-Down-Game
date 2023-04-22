using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{

    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }


    public override void EnterState() {
        _currentContext.currentSpeedMultiplier = 1;
    }

    public override void UpdateState() {
        CheckSwitchState();
        _currentContext.RotateCharacter();
        _currentContext.Movement();
        _currentContext.DetectAttack();
        _currentContext.DetectSpellCast();
        _currentContext.DetectInventory();
        _currentContext.StepDetect();
        _currentContext.animator.PlayAnimation("Idle");
    }

    public override void ExitState() { }

    public override void InitialiseSubState() { }

    public override void CheckSwitchState() { 
        //if player is inputting movement keys, switch to walk state
        if (_currentContext.input.InputVector.y != 0 | _currentContext.input.InputVector.x != 0)
        {
            SwitchState(_factory.Walk());
        }
    }
}
