using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public void changeToMenu(){
        if(SceneManager.GetActiveScene().name.Equals("MenuScene")) return;
        SceneManager.LoadScene("MenuScene");
        return;
    }

    public void changeToOption(){
        if(SceneManager.GetActiveScene().name.Equals("OptionScene")) return;
        SceneManager.LoadScene("OptionScene");
        return;
    }

    public void changeToMain(){
        if(SceneManager.GetActiveScene().name.Equals("MainScene")) return;
        SceneManager.LoadScene("MainScene");
        return;
    }

    public void changeToFirstFloor(){
        if(SceneManager.GetActiveScene().name.Equals("Floor(1)")) return;
        SceneManager.LoadScene("Floor(1)");
        return;
    }

    public void changeToSecondtFloor(){
        if(SceneManager.GetActiveScene().name.Equals("Floor(2)")) return;
        SceneManager.LoadScene("Floor(2)");
        return;
    }

    public void changeToThirdFloor(){
        if(SceneManager.GetActiveScene().name.Equals("Floor(3)")) return;
        SceneManager.LoadScene("Floor(3)");
        return;
    }

    public void quit(){
        if(SceneManager.GetActiveScene().name.Equals("MainScene")) Application.Quit();
        return;
    }
}
