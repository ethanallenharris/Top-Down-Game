using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : NPC
{
    public GameObject player { get; private set; }
    public bool canSeePlayer { get; set; }

    public GoblinVision goblinVision;

    public Animator goblinAnimator;

    private bool canAttack = true;
    private bool canMove = true;

    public Rigidbody rb;
    public float moveSpeed;

    public GameObject rightHand;
    private GameObject weaponHitbox;
    public GameObject hitbox;
    public Material modelMaterial;

    public Color originalColor;

    public float invincibilityTimer;

    public float health;

    public string goblinState = "normal";

    private bool invincibilityEnd = false;

    public float stunTimer;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        goblinVision.parent = gameObject;
        originalColor = modelMaterial.color;
    }

    void Update()
    {
        if(invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;           
        }

        switch (goblinState)
        {
            case "normal":
                if (canSeePlayer)
                {

                    if (ifInRange(gameObject, player, 1.6f) && canAttack)//if goblin is within 20 units of the player
                    {
                        //attack
                        goblinAnimator.Play("Attack");
                    }
                    else if (canMove)
                    {
                        //looks at player
                        Vector3 dir = player.transform.position - transform.position;
                        Quaternion lookRot = Quaternion.LookRotation(dir);
                        lookRot.x = 0; lookRot.z = 0;
                        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(3.0f * Time.maximumDeltaTime));


                        //play walk animation
                        goblinAnimator.Play("Walk");

                        //moves towards player
                        var speed = moveSpeed * Time.deltaTime;
                        Vector3 moveDirection = new Vector3(0, 0, 10);
                        transform.Translate(moveDirection * speed);
                    }

                }
                else
                {
                    goblinAnimator.Play("Idle");
                }
                break;
            case "hitStunned":
                if (stunTimer > 0)
                {
                    stunTimer -= Time.deltaTime;
                } else
                {
                    exitAttack();
                    goblinState = "normal";
                }
                break;
        }

       


    }

    private bool ifInRange(GameObject target1, GameObject target2, float range)
    {
        float distance = Vector3.Distance(target1.transform.position, target2.transform.position);
        //Debug.Log(distance);
        if (range > distance)
        {
            return true;//is in range
        }
        return false;//is not in range
    }

    private void MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;
        targetVector.y = 0;
        transform.Translate(targetVector * speed);
    }

    private void enterAttack()
    {
        canAttack = false;
        canMove = false;
    }

    private void hitboxBegin()
    {
        weaponHitbox = Instantiate(hitbox, rightHand.transform);
    }

    private void exitAttack()
    {
        canAttack = true;
        canMove = true;
        Destroy(weaponHitbox);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("general collision detected");
        if (other.tag == "PlayerAttackHitbox")
        {
            if (invincibilityTimer > 0) return;//if invincible do nothing
            PlayerAbilities playerAbilities = player.GetComponent<PlayerAbilities>();
            float reducedHealth = health - playerAbilities.newAttackDmg;
            Debug.Log("1");
            if (reducedHealth <= 0)
            {
                Destroy(gameObject);//dies
                return;
            }
            health = reducedHealth;
            Debug.Log("took damage");
            invincibilityTimer = 0.4f;
            modelMaterial.color = Color.white;
            goblinState = "hitStunned";
            stunTimer = 0.5f;
            goblinAnimator.Play("Hit Stun");
            Invoke("FlashStop", 0.4f);
        }
    }

    public void FlashStop()
    {
        modelMaterial.color = originalColor;
    }

}
