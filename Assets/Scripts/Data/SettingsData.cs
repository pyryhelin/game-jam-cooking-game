using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SettingsData : MonoBehaviour
{   
    float volume;

    void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                     + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedFloat = volume;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }
}

[Serializable]
class SaveData
{
    public int savedInt;
    public float savedFloat;
    public bool savedBool;


}

