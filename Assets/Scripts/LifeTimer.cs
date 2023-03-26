using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimer : MonoBehaviour
{
    public float LifeTime;

    // Update is called once per frame
    void Update()
    {
        if(LifeTime > 0)
        {
            LifeTime -= Time.deltaTime;
        } else {
            Destroy(gameObject);
        }
    }
}
