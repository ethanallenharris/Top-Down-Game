using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }


    public float speedMultiplier = 3.0f; // the maximum multiplier for player movement speed
    private float currentMultiplier = 1.0f; // the current multiplier for player movement speed

    private IEnumerator IncreaseSpeedCoroutine()
    {
        while (currentMultiplier < speedMultiplier)
        {
            currentMultiplier += Time.deltaTime;
            yield return null;
        }
        currentMultiplier = speedMultiplier;
    }


    public override void EnterState() 
    {
        CoroutineRunner.Instance.StartCoroutine(IncreaseSpeedCoroutine());
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        _currentContext.RotateCharacter();
        _currentContext.DetectAttack();
        _currentContext.DetectDash();
        _currentContext.DetectSpellCast();


        Vector2 InputVector = _currentContext.input.InputVector;

        Quaternion playerRotation = _currentContext.player.transform.rotation;

        // get float for run to sprint
        float RunMultFloat = (currentMultiplier - 1) / 2f;
        // change animator float value
        _currentContext.animator.GetAnimator().SetFloat("RunMult", RunMultFloat);

        // use the current multiplier to modify the player's movement speed
        float playerSpeed = _currentContext.playerMovespeed * currentMultiplier;

        // move player forward by playerSpeed
        _currentContext.playerEmpty.transform.Translate((new Vector3(0, 0, 1) * playerSpeed));

    }

    public override void ExitState() { }


    public override void InitialiseSubState() { }

    public override void CheckSwitchState()
    {
        //if player is no longer moving forward or holding shift
        if (_currentContext.input.InputVector.y < 1 || !Input.GetKey("left shift"))
        {
            SwitchState(_factory.Walk());
        }
    }
}