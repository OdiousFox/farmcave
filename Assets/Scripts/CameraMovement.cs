using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField] private GameObject target;
    private Vector3 targetPos;
    [SerializeField] private float height = -100;
    void Update() {
        targetPos = target.transform.position;
        transform.position = new Vector3(targetPos.x, targetPos.y, height);
    }
}
