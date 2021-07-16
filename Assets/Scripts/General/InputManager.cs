using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update() {
        if(Input.GetKeyDown(OwnKeybinds.invSlot1))
            PlayerStats.SelectSlot(0);
        if(Input.GetKeyDown(OwnKeybinds.invSlot2))
            PlayerStats.SelectSlot(1);
        if(Input.GetKeyDown(OwnKeybinds.invSlot3))
            PlayerStats.SelectSlot(2);
        if(Input.GetKeyDown(OwnKeybinds.invSlot4))
            PlayerStats.SelectSlot(3);
    }
}
