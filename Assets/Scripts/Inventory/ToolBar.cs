using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToolBar : MonoBehaviour
{
    
    [SerializeField] private int markerLocation = 0;
    [SerializeField] private GameObject player;
    
    
    public static event Action<int> sendMarker;

    private KeyCode[] keyCodes = {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
        KeyCode.Alpha0,
    };
    
    // Update is called once per frame
    void Update() {
        for (int i = 0; i < keyCodes.Length; i++) {
            if (Input.GetKeyDown(keyCodes[i])) {
                int numberPressed = i + 1;
                Debug.Log(numberPressed);
                SetMarker(markerLocation, false);
                markerLocation = i;
                SetMarker(i, true);
                SendMarker(i);
            }
        }
    }
    // Disables/Enables marker image
    private void SetMarker(int i, bool state) {
        transform.GetChild(i).Find("SelectionMarker").transform.GetComponent<Image>().enabled = state;
    }

    private void SendMarker(int i) {
        sendMarker?.Invoke(i);
    }
}

