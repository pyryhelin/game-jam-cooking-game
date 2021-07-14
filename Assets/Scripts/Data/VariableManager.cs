using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public static class VariableManager
{
    //Used to store instance data (variables etc.) between scenes.
    //This could be used for general data, and create a separate manager
    //for example player stats.

    //Doesn't need to be assigned to gameObejct as this is static 
    //class, and because of that this class cannot inherit the
    //monobehaviour class.

    //Example of how to implement: 

    private static int Example;
    public static int example
    {
        get
        {
            return Example;
        }
        set
        {
            //can add validation code such as:
            //if(value > 1)
            //  example = value;
            Example = value;
        }
    }
}



//used to store information related to player.
public static class PlayerStats
{


    //store player position
    private static Vector3 Position;
    public static Vector3 position
    {
        get
        {
            return Position;
        }
        set
        {
            Position = value;
        }
    }
}

public static class KitchenSceneObjectReferences{
    
    
    private static GameObject Player;
    public static GameObject player
    {
        get
        {
            return Player;
        }
        set
        {
            Player = value;
        }
    }

    private static GameObject Camera;
    public static GameObject camera
    {
        get
        {
            return Camera;
        }
        set
        {
            Camera = value;
        }
    }
}




[Serializable]
public class OwnResolution
{
    public int width;

    public int height;

    public int refreshRate;

}

[Serializable]
public class SerializableSettings{
    public OwnResolution resolution;
    public float volume;
    public int windowMode;



}

public static class SettingsData{
    private static Resolution Resolution;
    public static Resolution resolution
    {
        get
        {
            return Resolution;
        }
        set
        {
            Resolution = value;
        }
    }

    private static float Volume;
    public static float volume{
        get
        {
            return Volume;
        }
        set
        {
            Volume = value;
        }
    }

    private static int WindowMode;
    public static int windowMode{
        get
        {
            return WindowMode;
        }
        set
        {
            WindowMode = value;
        }
    }

    public static SerializableSettings GetSerializableSettings(){
        SerializableSettings SS = new SerializableSettings();
        SS.resolution = SettingsData.convertToOwnResolution(resolution);
        SS.volume = volume;
        SS.windowMode = windowMode;
        return SS;
    }

    public static void LoadSerializedSettings(SerializableSettings SS){
        resolution = SettingsData.convertFromOwnResolution(SS.resolution);
        windowMode = SS.windowMode;
        volume = SS.volume;
    }

    public static void SaveSettings()
    {
        SerializableSettings data = GetSerializableSettings();
        Debug.Log(data.resolution);
        Debug.Log(data.windowMode);
        Debug.Log(data.volume);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySettings.dat");
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");

    }


    public static bool LoadSettings()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySettings.dat", FileMode.Open);
            SerializableSettings data = (SerializableSettings)bf.Deserialize(file);
            file.Close();
            LoadSerializedSettings(data);
            Debug.Log("Game data loaded!");
            return true;
        }
        else{
            Debug.LogError("There is no save data!");
            return false;
            }
    }

    public static OwnResolution convertToOwnResolution(Resolution inputRes){
        OwnResolution res = new OwnResolution();
        res.height = inputRes.height;
        res.width = inputRes.width;
        res.refreshRate = inputRes.refreshRate;

        return res;


    }

    public static Resolution convertFromOwnResolution(OwnResolution inputRes){
        Resolution res =  new Resolution();
        res.height = inputRes.height;
        res.width = inputRes.width;
        res.refreshRate = inputRes.refreshRate;

        return res;

    }
}

