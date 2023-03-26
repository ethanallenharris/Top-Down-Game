using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed;
    private GameObject player;
    public GameObject Coin;
    public float Health;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //Health = FindObjectOfType<EnemySpawner>().getEnemyHealth();

    }


    // Update is called once per frame
    void Update()
    {
        try 
        {
            Vector3 lookVector = player.transform.position - transform.position;
            lookVector.y = transform.position.y;

            MoveTowardTarget(lookVector);
        } catch
        {

        }
    }

    private void MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;
        targetVector.y = 0;
        transform.Translate(targetVector * speed);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health = Health - collision.gameObject.GetComponent<BulletController>().damage;

            if (Health <= 0)
            {
                Destroy(gameObject);
                if (Random.Range(0, 4) == 3)
                {
                    Instantiate(Coin, gameObject.transform.position, gameObject.transform.rotation);
                }
            } 
        } 
    }
}
;