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
        GameObject book = Resources.Load<GameObject>("Prefabs/InventoryBook");
        _currentContext.EquipInHand(book, "left");
        _currentContext.animator.PlayAnimation("OpenInventory");
    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void ExitState()
    {

    }

    public override void InitialiseSubState() { }

    public override void CheckSwitchState()
    {
        //Exit inventory
        if (Input.GetButton("Inventory") && _currentContext.inventoryTimer <= 0)
        {
            _currentContext.inventoryObj.active = false;
            _currentContext.inventoryTimer = 1f;
            _currentContext.ClearHand("left");
            _currentContext.animator.PlayAnimation("RunForward");
            _currentContext.animator.PlayAnimation("Idle");
            SwitchState(_factory.Idle());
        }

    }
}