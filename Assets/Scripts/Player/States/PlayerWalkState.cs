using UnityEngine;
public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

    private float largestAxis = 0f;

    private Vector3 initialScale;

    private float scaleFactor;


    public override void EnterState() 
    {
        initialScale = _currentContext.player.transform.localScale;

        // Reset the child's scale to uniform based on the largest axis of the initial scale
        largestAxis = Mathf.Max(initialScale.x, initialScale.y, initialScale.z);

        // Adjust the other two axes to maintain the original proportions of the character
        scaleFactor = largestAxis / Mathf.Max(initialScale.x, initialScale.y, initialScale.z);
    }

    public override void UpdateState() {
        CheckSwitchState();
        _currentContext.Movement();
        _currentContext.RotateCharacter();
        _currentContext.DetectAttack();
        _currentContext.DetectDash();
        _currentContext.DetectSpellCast();
        _currentContext.StepDetect();

        _currentContext.animator.GetAnimator().SetFloat("RunMult", 0f);

        Vector2 InputVector = _currentContext.input.InputVector;

        Quaternion playerRotation = _currentContext.player.transform.rotation;


        //player not moving/no input detected
        if (InputVector.y == 0 && InputVector.x == 0)
        {
            _currentContext.animator.PlayAnimation("Idle");
            _currentContext.player.transform.rotation = _currentContext.playerEmpty.transform.rotation;
        }
               

        //player is only moving forward
        if (InputVector.y > 0 && InputVector.x == 0)
        {
            _currentContext.animator.PlayAnimation("RunForward");
            _currentContext.player.transform.rotation = _currentContext.playerEmpty.transform.rotation;
        }

        //player is moving diagonal forward + left
        if (InputVector.y > 0 && InputVector.x < 0)
        {
            _currentContext.animator.PlayAnimation("RunForward");
            _currentContext.player.transform.rotation = _currentContext.playerEmpty.transform.rotation;
            _currentContext.player.transform.localScale = new Vector3(initialScale.x * scaleFactor, initialScale.y * scaleFactor, initialScale.z * scaleFactor);
            _currentContext.player.transform.Rotate(0f, -45f, 0f);
        }

        //player is moving diagonal forward + right
        if (InputVector.y > 0 && InputVector.x > 0)
        {
            _currentContext.animator.PlayAnimation("RunForward");
            _currentContext.player.transform.rotation = _currentContext.playerEmpty.transform.rotation;
            _currentContext.player.transform.localScale = new Vector3(initialScale.x * scaleFactor, initialScale.y * scaleFactor, initialScale.z * scaleFactor);
            _currentContext.player.transform.Rotate(0f, 45f, 0f);
        }

        //Only running right
        if (InputVector.y == 0 && InputVector.x > 0)
        {
            _currentContext.animator.PlayAnimation("RunRight");
            _currentContext.player.transform.rotation = _currentContext.playerEmpty.transform.rotation;
        }
        

        //Only running left
        if (InputVector.y == 0 && InputVector.x < 0)
        {
            _currentContext.animator.PlayAnimation("RunLeft");
            _currentContext.player.transform.rotation = _currentContext.playerEmpty.transform.rotation;
        }
        

        //Only running back
        if (InputVector.y < 0)
        {
            _currentContext.animator.PlayAnimation("RunBack");
            _currentContext.player.transform.rotation = _currentContext.playerEmpty.transform.rotation;
        }

        //Only running back + left
        if (InputVector.y < 0 && InputVector.x < 0)
        {
            _currentContext.animator.PlayAnimation("RunBack");
            _currentContext.player.transform.rotation = _currentContext.playerEmpty.transform.rotation;
            _currentContext.player.transform.localScale = new Vector3(initialScale.x * scaleFactor, initialScale.y * scaleFactor, initialScale.z * scaleFactor);
            _currentContext.player.transform.Rotate(0f, 45f, 0f);
        }

        //Only running back + right
        if (InputVector.y < 0 && InputVector.x > 0)
        {
            _currentContext.animator.PlayAnimation("RunBack");
            _currentContext.player.transform.rotation = _currentContext.playerEmpty.transform.rotation;
            _currentContext.player.transform.localScale = new Vector3(initialScale.x * scaleFactor, initialScale.y * scaleFactor, initialScale.z * scaleFactor);
            _currentContext.player.transform.Rotate(0f, -45f, 0f);
        }



    }

    public override void ExitState() { }



    public override void InitialiseSubState() { }

    public override void CheckSwitchState() {
        //if player is not inputting movement keys, switch to idle state
        if (_currentContext.input.InputVector.y == 0 && _currentContext.input.InputVector.x == 0)
        {
            SwitchState(_factory.Idle());
            _currentContext.currentState.EnterState();
        }

        if (_currentContext.input.InputVector.y == 1 && _currentContext.input.InputVector.x == 0 && Input.GetKey("left shift"))
        {
            SwitchState(_factory.Run());
        }
    }
}
