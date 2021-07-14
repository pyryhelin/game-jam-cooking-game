using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OwnSceneManager.Start(OwnSceneManager.SceneType.MainMenu);
    }
    int seconds = 4;
    float timeElapsed = 0;

    bool loaded = false;
    // Update is called once per frame
    void Update()
    {
        if(timeElapsed > seconds && !loaded){
            loaded = true;
            LoadGame();   
        }
        timeElapsed += 1*Time.deltaTime;

    }

    private void LoadGame(){
        
        if(SettingsData.LoadSettings())
        {
        Screen.SetResolution(
            SettingsData.resolution.width, 
            SettingsData.resolution.height,
            (FullScreenMode)SettingsData.windowMode,
            SettingsData.resolution.refreshRate);

        }
        OwnSceneManager.LoadMainMenu();


    }
}
