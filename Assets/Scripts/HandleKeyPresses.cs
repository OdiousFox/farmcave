using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandleKeyPresses : MonoBehaviour {
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private UnityEvent _event;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode)) {
            _event?.Invoke();
            Debug.Log("eventhandler");
        }
    }
    
    

    
}
