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

    public bool isPaused;
    public bool isOpenedInventory;
    public bool isOpenedMap;
    public bool isOpenedQuest;

    void Awake(){
        instance = this;
        DontDestroyOnLoad(this);
        isPaused = false;
        isOpenedInventory = false;
        isOpenedMap = false;
        isOpenedQuest = false;


    }

    void Update(){
        if(currentState == GameState.inGame){
            if(Input.GetKeyDown(KeyCode.Escape)){
                gamePause();
            }

            if(!isPaused){
                if(Input.GetKeyDown(KeyCode.I)){
                    openInventory();
                }
                if(Input.GetKeyDown(KeyCode.M)){
                    openMap();
                }
                if(Input.GetKeyDown(KeyCode.Q)){
                    openQuest();
                }
            
                if(isOpenedInventory && Input.GetKeyDown(KeyCode.Escape)) openInventory();
                if(isOpenedMap && Input.GetKeyDown(KeyCode.Escape)) openMap();
                if(isOpenedQuest && Input.GetKeyDown(KeyCode.Escape)) openQuest();
            }
        }
    }

    public void gamePause(){
        if(currentState == GameState.inGame && !isPaused){
            isPaused = true;
        }
        else if(currentState == GameState.inGame && isPaused){
            isPaused = false;
        }
    }

    public void openInventory(){
        if(currentState != GameState.inGame || isPaused) return;

        if(!isOpenedInventory){
            isOpenedInventory = true;
            isOpenedMap = false;
            isOpenedQuest = false;
        }else{
            isOpenedInventory = false;
        }
    }

    public void openMap(){
        if(currentState != GameState.inGame || isPaused) return;

        if(!isOpenedMap){
            isOpenedMap = true;
            isOpenedInventory = false;
            isOpenedQuest = false;
        }else{
            isOpenedMap = false;
        }
    }

    public void openQuest(){
        if(currentState != GameState.inGame || isPaused) return;

        if(!isOpenedQuest){
            isOpenedQuest = true;
            isOpenedInventory = false;
            isOpenedMap = false;
        }else{
            isOpenedQuest = false;
        }
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
