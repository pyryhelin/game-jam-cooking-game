using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ResolutionDropdown : MonoBehaviour
{
    public GameObject resolutionDropdown;
    public TMP_Dropdown dropdown;
    
    Resolution[] availableResolutions;
    
    // Start is called before the first frame update
    void Start()
    {

        List<TMP_Dropdown.OptionData> dropdownData = new List<TMP_Dropdown.OptionData>();
        dropdown = resolutionDropdown.GetComponent<TMP_Dropdown>();
        dropdown.ClearOptions();
        availableResolutions = Screen.resolutions;
        

        Resolution currentResolution = new Resolution();

        currentResolution.height = Screen.height;
        currentResolution.width = Screen.width;
        currentResolution.refreshRate = Screen.currentResolution.refreshRate;
        TMP_Dropdown.OptionData curres = new TMP_Dropdown.OptionData();
        curres.text = currentResolution.ToString();
        dropdownData.Add(curres);

        for(int i = 0; i < availableResolutions.Length; i++){
            if(availableResolutions[i].ToString() == currentResolution.ToString())
            {
                continue;
            }
            TMP_Dropdown.OptionData newData = new TMP_Dropdown.OptionData();
            newData.text = availableResolutions[i].ToString();
            dropdownData.Add(newData);
            Debug.Log(availableResolutions[i].ToString());
        }
        dropdown.AddOptions(dropdownData);
        dropdown.SetValueWithoutNotify(0);
        dropdown.RefreshShownValue();
        Debug.Log(dropdown.options.ToArray()[0]);
        

    }

    public void setResolution(){
        SettingsData.resolution = availableResolutions[dropdown.value];
    }
}
