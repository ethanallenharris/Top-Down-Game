using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryState : PlayerBaseState
{
    public PlayerInventoryState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }


    public override void EnterState() { }

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
        //if (Input.GetButton("Inventory") && _currentContext.InventoryTimer <= 0)
        //{
        //    _currentContext.inventoryTimer = _currentContext.InventorySetTime;
        //    //_currentContext.inventoryToggle(false);
        //    SwitchState(_factory.Idle());
        //}

    }
}
