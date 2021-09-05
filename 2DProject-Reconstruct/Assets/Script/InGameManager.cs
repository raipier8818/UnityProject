using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public bool isPaused;
    public bool isOpenedInventory;
    public bool isOpenedMap;
    public bool isOpenedQuest;

    // Start is called before the first frame update
    private void Awake() {
        isPaused = false;
        isOpenedInventory = false;
        isOpenedMap = false;
        isOpenedQuest = false;
    }

    public static bool setTimeScale(){
        return (isPaused || isOpenedInventory || isOpenedMap || isOpenedQuest);
    }
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gamePause(){
        isPaused = !isPaused;
    }

    public void openInventory(){
        if(isPaused) return;

        if(!isOpenedInventory){
            isOpenedInventory = true;
            isOpenedMap = false;
            isOpenedQuest = false;
        }else{
            isOpenedInventory = false;
        }
    }

    public void openMap(){
        if(isPaused) return;

        if(!isOpenedMap){
            isOpenedMap = true;
            isOpenedInventory = false;
            isOpenedQuest = false;
        }else{
            isOpenedMap = false;
        }
    }

    public void openQuest(){
        if(isPaused) return;

        if(!isOpenedQuest){
            isOpenedQuest = true;
            isOpenedInventory = false;
            isOpenedMap = false;
        }else{
            isOpenedQuest = false;
        }
    }    
}
