using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using System;

public class PlayerStateMachine : MonoBehaviour
{

    //Player state machine acts like the brain of the player.
    //This is responsible for allowing player movement, inventory access, spell casting etc
    //This is done by putting players into states with thier each exit case

    #region variables

    //References
    public Camera camera;
    public GameManager gameManager;
    public PlayerAbilities playerAbilities;
    public Timer timer;

    //Player
    public GameObject playerEmpty;
    public GameObject player;
    public AnimatorScript animator;

    //Player Scripts
    public BaseStats baseStats;
    public InputHandler input;

    //going to need:
    //player (will have command for default for player stats after buffs/debuffs)
    //player script requirements:

    //reset player stats after equipment changed/buff/debuffed
    //handles passives
    //current equipments/armor/trinkets
    //handles interacting with inventory script
    //buffs/debuffs

    //playerSpells script
    //Has players spells

    //player Stats
    public float playerMovespeed;


    //States
    public PlayerBaseState currentState;
    PlayerStateFactory states;
    private string playerCurrentState;

    //Timers
    public float inventoryTimer;
    public float dashTimer;

    //UI objects
    public GameObject inventoryObj;



    public Vector3 rotationOffset { get; set; }


    #endregion

    //intitiates player state machine
    void Awake()
    {
        states = new PlayerStateFactory(this);
        currentState = states.Idle();
        currentState.EnterState();
    }

    void Update()
    {
        CameraFollowPlayer();

        //dash cooldown

        //count down timers
        currentState.UpdateState();
        if (inventoryTimer >= 0)
            inventoryTimer -= Time.deltaTime;
        if (dashTimer >= 0)
            dashTimer -= Time.deltaTime;

    }

    #region active
    public void Dash()
    {
        //logic to make player dash

        //enter dash state
        //make invincible
        //activate SFX / sound
        //play animation

        //lock other movement options
        //move player in direction fast

        //after return to running/idle based on player input
    }

    public bool DetectDash()
    {
        //change to get stamina and change stamina from basestats
        //if (Input.GetButton("spacebar") && dashTimer <= 0 && (0 <= baseStats.CurrentStamina - 1))
        if (Input.GetButton("spacebar"))
        {
            baseStats.CurrentStamina -= 10;
            Debug.Log("Dash detected");
            dashTimer = 0.6f;
            //initiates dash

            currentState = states.Dash();
            states.Dash().EnterState();
            return true;
        }
        return false;
    }

    public void Movement()
    {
        //moves player according to players inputs
        playerEmpty.transform.Translate(rotationOffset + (new Vector3(input.InputVector.x, 0, input.InputVector.y) * playerMovespeed));
    }

    public bool DetectSpellCast()
    {
        //based on if input.Number1 == active && == spellslot[1].available == free
        //if spellSlot[1].spell.mobile == false
        //stop player movement for cast duration
        //play animation
        //add SFX/Sound
        //player can get interrupted
        // .castSpell

        //and do opposide but do not restrict player movement if spell can be cast while moving

        //enter cast state (can be knocked out of cast state)

        //if (Input.GetMouseButtonDown(0)) playerAbilities.castSpell();

        return false;
    }

    //will rotate character to mouse
    public void RotateCharacter()
    {
        Ray cameraRay = camera.ScreenPointToRay(input.Mouseposition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            playerEmpty.transform.LookAt(new Vector3(pointToLook.x, playerEmpty.transform.position.y, pointToLook.z));
        }
    }

    public void PlayerAttack()
    {
        //Detect input for attack

        //check player is not silenced/stunned

        //enter attack state (can be knocked out of it)

        if (Input.GetMouseButtonDown(0)) playerAbilities.startAttack();
    }

    //these act like listeners that can be placed within states
    public bool DetectAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerAttack();
        }
        return Input.GetMouseButtonDown(0);
    }


    public void DetectInventory()
    {
        if (Input.GetButton("Inventory") && inventoryTimer <= 0)//if inventory button is pressed && timer is < 0
        {
            Debug.Log("Inventory toggle");
            currentState = states.Inventory();
            states.Inventory().EnterState();
            inventoryTimer = 1f;
            //enter play inventory animation and open inventory UI
            //enter inventory state
        }
    }

    public float CameraX;
    public float CameraY;
    public float CameraZ;
    public void CameraFollowPlayer()
    {
        camera.transform.position = playerEmpty.transform.position + new Vector3(CameraX, CameraY, CameraZ);
    }

    #endregion


    //LEFT OFF ON PLAYER IDLE STATE




    //public void executeSpell(int spellSlot)
    //{
    //    if (Input.GetMouseButtonDown(0)) playerAbilities.castSpell();
    //}

    //public bool detectDash()
    //{
    //    if (Input.GetButton("spacebar") && playerDashCooldown <= 0 && (0 <= playerAbilities.currentStamina - 1))
    //    {
    //        playerAbilities.currentStamina -= 1;
    //        playerDashCooldown = playerDashTime;
    //        return true;
    //    }
    //    return false;
    //}


    //public void executeMovement()
    //{
    //    _player.transform.Translate(new Vector3(_input.InputVector.x, 0, _input.InputVector.y) * playerAbilities.newSpeed);
    //    //, Space.World
    //}

    //public void rotateCharacter()
    //{
    //    Ray cameraRay = _camera.ScreenPointToRay(_input.Mouseposition);
    //    Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
    //    float rayLength;

    //    if (groundPlane.Raycast(cameraRay, out rayLength))
    //    {
    //        Vector3 pointToLook = cameraRay.GetPoint(rayLength);
    //        Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
    //        _player.transform.LookAt(new Vector3(pointToLook.x, _player.transform.position.y, pointToLook.z));
    //    }
    //}

    //public void inventoryToggle(bool inventory)
    //{
    //    //true = enter
    //    //false = close
    //    if (inventory)
    //    {
    //        _gameManager.changeMenuState("openBook inventory");
    //        inventoryTimer = inventoryToggleTime;
    //    } else {
    //        _gameManager.changeMenuState("closeBook");
    //        inventoryTimer = inventoryToggleTime;
    //    }

    //}

    //public void playerAttack()
    //{
    //    if (Input.GetMouseButtonDown(0)) playerAbilities.startAttack();
    //}

    //public void playerDashMovement()
    //{
    //    var speed = playerAbilities.newSpeed * 1.5f;
    //    _player.transform.Translate(new Vector3(_input.InputVector.x, 0, _input.InputVector.y) * speed);
    //}


    //public void enableAttacks()
    //{
    //    playerAbilities.inAttack = true;
    //}

    //public void disableAttacks()
    //{
    //    playerAbilities.inAttack = false;
    //}



}
