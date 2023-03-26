using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectButton : MonoBehaviour
{

    public GameManager gameManager;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            //gameManager.changeMenuState("mainMenu main");
        }
    }
}
