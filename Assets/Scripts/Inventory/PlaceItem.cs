using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaceItem : MonoBehaviour {

    [SerializeField] private List<ItemData> placeables;
    private ItemData currentItem;
    
    private void OnEnable() {
        ToolBar.sendItem += Activate;
    }
    
    private void OnDisable() {
        ToolBar.sendItem -= Activate;
    }

    private void Activate(ItemData item) {
        currentItem = item;
    }
    
    
    void Update()
    {
        if (currentItem != null && Input.GetMouseButtonDown(1)) {
            Vector3 location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            location = new Vector3((float)Math.Floor(location.x) + 0.5f, (float)Math.Floor(location.y) + 0.5f, -1);
            Instantiate(currentItem.PlaceablePrefab, location, Quaternion.identity);
        }
    }
}
