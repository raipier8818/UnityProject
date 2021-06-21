using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject InventoryUI;
    public GameObject MapUI;
    public GameObject QuestUI;
    void Awake(){
        
    }

    void Update(){
        InGameLoad();

        if(GameManager.instance.isPaused || GameManager.instance.isOpenedInventory || GameManager.instance.isOpenedMap || GameManager.instance.isOpenedQuest){
            Time.timeScale = 0;
        }else{
            Time.timeScale = 1;
        }
    }

    public void ResumeButton(){
        GameManager.instance.gamePause();
    }

    public void OptionButton(){
        
    }

    public void QuitButton(){
        GameManager.instance.ChangeMainMenu();
    }

    public void InGameLoad(){
        PauseUI.SetActive(GameManager.instance.isPaused);
        InventoryUI.SetActive(GameManager.instance.isOpenedInventory);
        MapUI.SetActive(GameManager.instance.isOpenedMap);
        QuestUI.SetActive(GameManager.instance.isOpenedQuest);
    }
}
