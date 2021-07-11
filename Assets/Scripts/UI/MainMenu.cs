using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    //Loads the next scene in the queue
    public void PlayGame()
    {
        SceneManager.LoadScene("kitchen");
    }

    //Exits game
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

}
