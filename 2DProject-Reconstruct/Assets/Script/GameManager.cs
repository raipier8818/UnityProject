using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState{
    mainMenu,
    optionMenu,
    inGame
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState currentState;

    void Awake(){
        instance = this;
    }

    void Update(){
        
    }

    

    public void ChangeMainMenu(){
        Debug.Log("Change Scene");
        SceneManager.LoadScene("MenuScene");
        GameManager.instance.currentState = GameState.mainMenu;
    }

    public void ChangeInGame(){
        Debug.Log("Change Scene");
        SceneManager.LoadScene("InGameScene");
        GameManager.instance.currentState = GameState.inGame;
    }

    public void ChangeOption(){

    }

    public void Quit(){
        Application.Quit();
    }
}
