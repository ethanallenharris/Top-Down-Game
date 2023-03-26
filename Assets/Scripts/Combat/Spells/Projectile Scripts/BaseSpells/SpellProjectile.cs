using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectile : MonoBehaviour
{
    public float speed = 10f;
    public GameObject explosionPrefab;

    protected virtual void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {

    }
}
