using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    private PlayerAbilities playerAbilities;

    private InputHandler _input;

    [SerializeField]
    private float moveSpeed;

    private Rigidbody myRigidBody;

    private Camera mainCamera;

    public GunController theGun;

    public float dashCoolDown = 3;

    private float dashTimeLeft;

    public int maxHealth;

    private int health;

    public Image healthBar;

    //private PlayerAnimation playerAnimation;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
        mainCamera = FindObjectOfType<Camera>();
        playerAbilities = FindObjectOfType<PlayerAbilities>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        //playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {

        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);


        MoveTowardTarget(targetVector);

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
         
        }

           


        //if (Input.GetMouseButtonDown(0))
            //theGun.isFiring = true;
        //if (Input.GetMouseButtonUp(0))
            //theGun.isFiring = false;


        //if (dashTimeLeft > 0)
            //dashTimeLeft -= Time.deltaTime;

        //if (Input.GetButton("spacebar") && dashTimeLeft <= 0.0f)
        //{
        //    dashTimeLeft = dashCoolDown;
        //    Dash(targetVector);
        //}
        //UpdateStamina(dashTimeLeft / dashCoolDown);

    }


    private void MoveTowardTarget(Vector3 direction)
    {
        var speed = playerAbilities.newSpeed * Time.deltaTime;
        transform.Translate(direction * speed);
        //, Space.World
    }

    //private void Dash(Vector3 direction)
    //{
    //    float dashTime = 1;
    //    while (dashTime > 0)
    //    {
    //        var speed = (playerAbilities.newSpeed * 1.2f) * Time.deltaTime;
    //        transform.Translate(direction * speed, Space.World);
    //        dashTime -= Time.deltaTime;
    //    }

    //}

    //public void UpdateStamina(float fraction)
    //{
    //    staminaBar.fillAmount = 1 - fraction;
    //}


    //public void UpdateHealth(int change)
    //{

    //    playerAbilities.currentHealth += change;

    //    if (playerAbilities.currentHealth > playerAbilities.newHealth)
    //        playerAbilities.currentHealth = playerAbilities.newHealth;

    //    if (health <= 0)
    //    {
    //        //FindObjectOfType<GameManager>().EndGame();
    //        Destroy(gameObject);
    //    }

    //    healthBar.fillAmount = (float) playerAbilities.currentHealth / playerAbilities.newHealth;

    //}


}
