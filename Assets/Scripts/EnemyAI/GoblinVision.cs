using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinVision : MonoBehaviour
{

    public GameObject parent;
    public Goblin goblin;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = parent.transform.position;
    }

    private void Start()
    {
        goblin = parent.GetComponent<Goblin>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //maybe make an alert trigger
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            goblin.canSeePlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            goblin.canSeePlayer = false;
        }
    }


}
