using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class OwnSceneManager
{

    //different types of 
    public enum SceneType
    {
        Main,
        Minigame,
        Container,
        MainMenu,
        Menu,
        Dialogue,
        None
    }


    //dictianry to store active scenes as and their corresponding types as key-value pairs.
    //used for handling scene unloading.  
    static Dictionary<Scene, SceneType> activeScenes = new Dictionary<Scene, SceneType>();



    //variables to keep track of past, current, and future scenes. Used for scene loading. 
    private static SceneType unloadedSceneType;
    public static SceneType activeSceneType;
    private static bool setNextSceneAsActive = false;
    private static SceneType nextSceneType;
    private static Scene lastActiveScene;
    private static SceneType lastActiveSceneType;
    private static bool currentlyLoading = false;


    //this start method is called from MainMenu.cs's start method, which will be run at the very start of the game.
    //!!!If testing individual scene, make sure to call this method from somewhere in the scene!!!
    public static void Start(SceneType currentScene)
    {

        activeSceneType = currentScene;
        activeScenes.Add(SceneManager.GetActiveScene(), activeSceneType);
        //add event listeners "OnSceneLoad" for scene laoding and "OnSceneUnload for unloading
        SceneManager.sceneLoaded += OnSceneLoad;
        SceneManager.sceneUnloaded += OnSceneUnload;
    }


    //handle different scene unloading. 
    private static void OnSceneUnload(Scene scene)
    {


        //define functionality for unloading for each type of scene. 
        switch (unloadedSceneType)
        {
            case SceneType.Minigame:
                SetActiveScene(lastActiveScene);
                KitchenSceneObjectReferences.player.SetActive(true);
                KitchenSceneObjectReferences.camera.SetActive(true);
                break;
        }
    }



    private static void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log(nextScene);

        //add scene and its type to the activeScenes dictionary.
        activeScenes.Add(scene, nextSceneType);

        //
        switch (nextSceneType)
        {
            case SceneType.Minigame:
                KitchenSceneObjectReferences.player.SetActive(false);
                KitchenSceneObjectReferences.camera.SetActive(false);
                break;
            case SceneType.Main:

                break;
        }


        //if the setNextSceneAsActive is set to true, set loaded scene as current active scene
        //chnage last scene and active scene variables to reflect the changes.
        if (setNextSceneAsActive)
        {
            lastActiveSceneType = activeSceneType;
            lastActiveScene = SceneManager.GetActiveScene();
            activeSceneType = nextSceneType;
            nextSceneType = SceneType.None;
            setNextSceneAsActive = false;
            SetActiveScene(scene);
        }

        currentlyLoading = false;
    }

    private static void LoadSceneByName(string sceneName, LoadSceneMode loadMode)
    {
        SceneManager.LoadSceneAsync(sceneName, loadMode);

    }

    private static void UnloadSceneByName(string sceneName)
    {
        Scene sceneToUnload = SceneManager.GetSceneByName(sceneName);
        unloadedSceneType = activeScenes[sceneToUnload];
        Debug.Log(unloadedSceneType);
        SceneManager.UnloadSceneAsync(sceneToUnload);

    }

    private static void UnloadCurrentScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        unloadedSceneType = activeSceneType;
    }

    private static void SetActiveSceneByName(string name)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));

    }

    private static void SetActiveScene(Scene scene)
    {
        SceneManager.SetActiveScene(scene);
    }

    public static void LoadMinigame(string name)
    {
        if (!currentlyLoading)
        {
            nextSceneType = SceneType.Minigame;
            setNextSceneAsActive = true;
            currentlyLoading = true;
            LoadSceneByName(name, LoadSceneMode.Additive);
        }
    }

    public static void ExitMinigame()
    {
        UnloadCurrentScene();
    }


    public static void LoadMainGame(){
        if(!currentlyLoading){
            nextSceneType = SceneType.Main;
            setNextSceneAsActive = true;
            currentlyLoading = true;
            LoadSceneByName("KitchenModular", LoadSceneMode.Single);
        }

    }
}
