using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }


    public float speedMultiplier = 3.0f; // the maximum multiplier for player movement speed
    

    private IEnumerator IncreaseSpeedCoroutine()
    {
        while (_currentContext.currentSpeedMultiplier < speedMultiplier)
        {
            _currentContext.currentSpeedMultiplier += Time.deltaTime;
            yield return null;
        }
        _currentContext.currentSpeedMultiplier = speedMultiplier;
    }


    public override void EnterState() 
    {
        CoroutineRunner.Instance.StartCoroutine(IncreaseSpeedCoroutine());
        Debug.Log("Entering run");
        _currentContext.animator.GetAnimator().SetFloat("RunMult", 0);
        _currentContext.animator.PlayAnimation("RunForward");
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        _currentContext.RotateCharacter();
        _currentContext.DetectAttack();
        _currentContext.DetectDash();
        _currentContext.DetectSpellCast();
        _currentContext.StepDetect();


        Vector2 InputVector = _currentContext.input.InputVector;

        Quaternion playerRotation = _currentContext.player.transform.rotation;

        // get float for run to sprint
        float RunMultFloat = (_currentContext.currentSpeedMultiplier - 1) / 2f;
        // change animator float value
        _currentContext.animator.GetAnimator().SetFloat("RunMult", RunMultFloat);

        // use the current multiplier to modify the player's movement speed
        float playerSpeed = _currentContext.playerMovespeed * _currentContext.currentSpeedMultiplier;

        // move player forward by playerSpeed
        _currentContext.playerEmpty.transform.Translate(new Vector3(0, 0, 1) * playerSpeed);

    }

    public override void ExitState() { }


    public override void InitialiseSubState() { }

    public override void CheckSwitchState()
    {
        //if player is no longer moving forward or holding shift
        if (_currentContext.input.InputVector.y < 1 | !Input.GetKey("left shift"))
        {
            Debug.Log("Stopped running");
            _currentContext.currentSpeedMultiplier = 1;
            _currentContext.animator.GetAnimator().SetFloat("RunMult", 0);
            SwitchState(_factory.Walk());
        }
    }
}