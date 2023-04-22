using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventHandler : MonoBehaviour
{

    //Get player state machine
    public PlayerStateMachine playerStateMachine;

    public void EnterIdle()
    {
        playerStateMachine.EnterIdle();
    }

    public void SetStepState(string direction)
    {
        playerStateMachine.EnterStep(direction);
    }

    public void ExitRoll()
    {
        if (playerStateMachine.currentSpeedMultiplier > 1)
        {
            playerStateMachine.animator.GetAnimator().SetFloat("RunMult", 0f);
            playerStateMachine.EnterRun();
        } else
        {
            playerStateMachine.EnterIdle();
        }
    }


}
