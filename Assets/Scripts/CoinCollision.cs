using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    public float coinLifetime;

    private void Update()
    {
        coinLifetime -= Time.deltaTime;
        if (coinLifetime <= 0)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}
