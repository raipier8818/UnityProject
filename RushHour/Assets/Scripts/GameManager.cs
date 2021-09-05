using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    KeyManager keys;
    bool isPaused = false;

    void Awake() {
        instance = this;
        instance.isPaused = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inGamePause(){
        Time.timeScale = 0f;
    }

    public void inGameRestart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
