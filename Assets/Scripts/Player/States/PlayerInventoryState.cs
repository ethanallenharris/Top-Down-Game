using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryState : PlayerBaseState
{
    public PlayerInventoryState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }


    public override void EnterState() 
    {
        _currentContext.inventoryObj.active = true;
    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void ExitState() {
       
    }

    public override void InitialiseSubState() { }

    public override void CheckSwitchState()
    {
        //if player is inputting movement keys, switch to walk state
        if (Input.GetButton("Inventory") && _currentContext.inventoryTimer <= 0)
        {
            _currentContext.inventoryObj.active = false;
            _currentContext.inventoryTimer = 1f;
            SwitchState(_factory.Idle()) ;
        }

    }
}
