using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
       
    //Loads the next scene in the queue
    public void PlayGame()
    {
        OwnSceneManager.LoadMainGame();
    }

    //Exits game
    public void ExitGame()
    {
        Debug.Log("Exit");
        SettingsData.SaveSettings();
        Application.Quit();
    }

    
}
