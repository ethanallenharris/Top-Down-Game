using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject camera;

    public GameObject player;

    private PlayerStateMachine playerController;

    public string menuState;

    GameState gameState = GameState.Loading;


    enum GameState
    {
        Loading,
        InGame,
        Pause,
        EndGame,
    };


    void Start()
    {

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Method to change state of the game
    public void changeGameState(string gameStateStr)
    {
        switch (gameStateStr)
        {
            case "Loading":
                gameState = GameState.Loading;
                break;

            case "InGame":
                gameState = GameState.InGame;
                break;

            case "Pause":
                gameState = GameState.Pause;
                break;

            case "EndGame":
                gameState = GameState.EndGame;
                Debug.Log("GAME OVER");
                Restart();
                break;

            default:
                Debug.Log(gameStateStr + " is an invalid game state (GameManager)");
                break;
        }

    }


    //public void changeMenuState(string newState)
    //{
    //    switch (newState)
    //    {
    //        //case "startScreen":
    //        //    startScreen.SetActive(true);
    //        //    break;
    //        //case "mainMenu main":
    //        //    startScreen.SetActive(false);
    //        //    gameOver.SetActive(false);
    //        //    mainMenu.SetActive(true);
    //        //    mainMenu.GetComponent<Transform>().Find("SettingsPage").GetComponent<Canvas>().enabled = false;
    //        //    mainMenu.GetComponent<Transform>().Find("MainPage").GetComponent<Canvas>().enabled = true;
    //        //    inGame.SetActive(false);
    //        //    break;
    //        //case "mainMenu settings":
    //        //    mainMenu.GetComponent<Transform>().Find("MainPage").GetComponent<Canvas>().enabled = false;
    //        //    mainMenu.GetComponent<Transform>().Find("SettingsPage").GetComponent<Canvas>().enabled = true;
    //        //    break;
    //        //case "enterGame":
    //        //    player.GetComponent<PlayerAnimation>().ChangeAnimationState("Idle");
    //        //    mainMenu.SetActive(false);
    //        //    inGame.SetActive(true);
    //        //    changeMenuState("closeBook");
    //        //    playerController.enabled = true;
    //        //    break;    
    //        case "openBook inventory":
    //            inGame.GetComponent<Transform>().Find("HUD").GetComponent<Canvas>().enabled = false;
    //            inGame.GetComponent<Transform>().Find("Book").GetComponent<Canvas>().enabled = true;
    //            inGame.GetComponent<Transform>().Find("Book").GetComponent<Transform>().Find("Settings").GetComponent<Canvas>().enabled = false;
    //            inGame.GetComponent<Transform>().Find("Book").GetComponent<Transform>().Find("Inventory").GetComponent<Canvas>().enabled = true;
    //            break;
    //        case "openBook settings":
    //            inGame.GetComponent<Transform>().Find("Book").GetComponent<Transform>().Find("Settings").GetComponent<Canvas>().enabled = true;
    //            inGame.GetComponent<Transform>().Find("Book").GetComponent<Transform>().Find("Inventory").GetComponent<Canvas>().enabled = false;
    //            break;
    //        case "gameOver":
    //            inGame.SetActive(false);
    //            gameOver.SetActive(true);
    //            break;
    //        case "closeBook":
    //            inGame.GetComponent<Transform>().Find("Book").GetComponent<Canvas>().enabled = false;
    //            inGame.GetComponent<Transform>().Find("HUD").GetComponent<Canvas>().enabled = true;
    //            break;
    //    }
    //}


}
