using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Rigidbody2D rigidBody;
    private Vector2 movement;
    // Update is called once per frame
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed);
    }
    
}
