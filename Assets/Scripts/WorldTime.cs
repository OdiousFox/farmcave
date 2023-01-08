using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTime : MonoBehaviour {

    private float timer;

    public static event Action passDay;  

    public float Timer {
        get => timer;
        set => timer = value;
    }

    // Update is called once per frame
    void Update() {
        // timer += Time.deltaTime;
        // Math.Floor(timer);
        // if (timer % 10 == 0) PassDay();
        if (Input.GetKeyDown(KeyCode.Q)) PassDay();
    }

    private void PassDay() {
        Debug.Log("Pass day.");
        passDay?.Invoke();
    }
}
