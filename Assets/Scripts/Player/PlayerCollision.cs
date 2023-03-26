using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{

    public float InvicibilityFramesMax;
    private float InvicibilityFrames;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && InvicibilityFrames <= 0)
        {
            InvicibilityFrames = InvicibilityFramesMax;
            //FindObjectOfType<PlayerMovement>().UpdateHealth(-1);
        }
    }

    void Update()
    {
        InvicibilityFrames -= Time.deltaTime;
    }

}
