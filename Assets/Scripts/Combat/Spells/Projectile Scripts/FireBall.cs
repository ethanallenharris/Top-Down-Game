using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : SpellProjectile
{

    protected override void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);

        base.OnCollisionEnter(collision);
    }
}
