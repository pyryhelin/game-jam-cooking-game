using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class OwnSceneManager
{   

    //different types of 
    enum SceneType
    {
        Main,
        Minigame,
        Container,
        Menu,
        Dialogue
    }
    private static bool setNextSceneAsActive = false;
    private static SceneType nextScene;

    private static string lastActiveScene;
    // private static GameObject player; 
    
    // private void Awake() {
    //     //keeps the object alive when changing scenes,
    //     //must be in Awake()
    //     //DontDestroyOnLoad(this.gameObject); 
    // }

    // private void Start(){
    //     player = GameObject.FindWithTag("Player");
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }
    public static void Start(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        Debug.Log(nextScene);
        switch(nextScene)
        {
            case SceneType.Minigame:
                KitchenSceneObjectReferences.player.SetActive(false);
                KitchenSceneObjectReferences.camera.SetActive(false);
                lastActiveScene = SceneManager.GetActiveScene().name;
                break;

        
        }
        if(setNextSceneAsActive)
        {
            SetActiveScene(scene);
        }
    }

    private static void LoadSceneByName(string sceneName){
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

    }

    private static void UnloadSceneByName(string sceneName){
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(sceneName));
    }

    private static void UnloadCurrentScene(){
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    private static void SetActiveSceneByName(string name){
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
        
    }

    private static void SetActiveScene(Scene scene){
        SceneManager.SetActiveScene(scene);   
    }

    public static void LoadMinigame(string name){
        nextScene = SceneType.Minigame;
        setNextSceneAsActive = true;
        LoadSceneByName(name);
    }

    public static void ExitMinigame(){
        UnloadCurrentScene();
        SetActiveSceneByName(lastActiveScene);
        KitchenSceneObjectReferences.player.SetActive(true);
        KitchenSceneObjectReferences.camera.SetActive(true);
        Debug.Log("ass");
    }
}
