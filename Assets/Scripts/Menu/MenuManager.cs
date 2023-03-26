using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameManager gameManager;

    public void start()
    {
        //gameManager.changeMenuState("enterGame");
    }

    public void settings()
    {
        //gameManager.changeMenuState("mainMenu settings");
    }

    public void exitGame()
    {
        //exit game
        //Debug.Log("exit");
    }

    public void backToMainMenu()
    {
        //gameManager.changeMenuState("mainMenu main");
    }
}
