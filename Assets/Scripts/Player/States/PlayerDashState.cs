using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    public PlayerDashState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

    private float dashDuration = 1.1f;

    private float x;
    private float y;

    public override void EnterState()
    {
        //On enter state get mouse point.
        //get direction from player to mouse
        //push player in direction
        //play dash animation
        //after dash done, exit state

        Debug.Log("WE in dash state baby");


        //getDashDirection();
        _currentContext.animator.PlayAnimation("Roll");
    }


    public override void UpdateState()
    {
        //CheckSwitchState();
        //_currentContext.playerDashMovement();
        //dashDuration -= Time.deltaTime;

        _currentContext.playerEmpty.transform.Translate(new Vector3(0, 0, 1) * 0.015f);
    }

    public override void ExitState() { }

    public override void InitialiseSubState() { }

    public override void CheckSwitchState()
    {
        if (dashDuration <= 0)
        {
            //_currentContext.Animator.ChangeAnimationState("Idle");
            //SwitchState(_factory.Walk());
        }
    }

    public void getDashDirection()
    {
        //x = _currentContext.InputHandler.InputVector.x;
        //y = _currentContext.InputHandler.InputVector.y;
    }
}

