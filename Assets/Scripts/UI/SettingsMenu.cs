using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    private TMP_Dropdown resolutionDropdown;

    private Resolution[] availableResolutions;

    private void Start() {
        GameObject.Find("WindowModeDropdown").GetComponent<TMP_Dropdown>().SetValueWithoutNotify(SettingsData.windowMode);
        resolutionDropdown = GameObject.Find("Resolutions").GetComponent<TMP_Dropdown>();
        SetResolutionDropdownOptions();
        for(int i = 0; i< availableResolutions.Length; i++){
            if(availableResolutions[i].ToString() == SettingsData.resolution.ToString())
                resolutionDropdown.SetValueWithoutNotify(i);
        }
    }

    public void SetResolutionDropdownOptions(){
        
        List<TMP_Dropdown.OptionData> dropdownData = new List<TMP_Dropdown.OptionData>();
        resolutionDropdown = resolutionDropdown.GetComponent<TMP_Dropdown>();
        resolutionDropdown.ClearOptions();
        availableResolutions = Screen.resolutions;


     
      
        for(int i = 0; i < availableResolutions.Length; i++){
            TMP_Dropdown.OptionData newData = new TMP_Dropdown.OptionData();
            newData.text = availableResolutions[i].ToString();
            dropdownData.Add(newData);
            //Debug.Log(availableResolutions[i].ToString());
        }
        resolutionDropdown.AddOptions(dropdownData);
        resolutionDropdown.SetValueWithoutNotify(0);
        resolutionDropdown.RefreshShownValue();
        Debug.Log(resolutionDropdown.options.ToArray()[0]);
        
    }

     public void setResolution(){
        SettingsData.resolution = availableResolutions[resolutionDropdown.value];
        Screen.SetResolution(
            SettingsData.resolution.width,
            SettingsData.resolution.height, 
            (FullScreenMode)SettingsData.windowMode, 
            SettingsData.resolution.refreshRate);
    }

    public void SaveSettings(){
        SettingsData.SaveSettings();
        }

    public void SetVolume(float volume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
        SettingsData.volume = volume;
    }



    public void SetWindowMode(){
        SettingsData.windowMode = GameObject.Find("WindowModeDropdown").GetComponent<TMP_Dropdown>().value;
    }


}
