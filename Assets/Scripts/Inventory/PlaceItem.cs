using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlaceItem : MonoBehaviour {

    [SerializeField] private List<ItemData> placeables;
    [SerializeField] private GameObject player;
    
    [SerializeField] private GameObject placementIndicator;
    private GameObject indicator;
    
    private ItemData currentItem;
    private int toolbarIndex = -1;
    
    private Camera camera;
    private Inventory inv;
    
    private void OnEnable() {
        ToolBar.sendMarker += Activate;
    }
    
    private void OnDisable() {
        ToolBar.sendMarker -= Activate;
    }

    private void Activate(int toolbarOrigin) {
        toolbarIndex = toolbarOrigin;
    }

    private void Start() {
        camera = Camera.main;
        inv = player.GetComponent<Inventory>();
        indicator = Instantiate(placementIndicator, new Vector3( 0, 0, -10), Quaternion.identity);
        indicator.SetActive(false);

    }

    void Update() {
        if (toolbarIndex != -1) {
            // if an item exists at the current location in inventory, set the current item to it
            // otherwise change it to null, used in case item changed from 1 to 0 from remove
            if (inv.inventory.ContainsKey(toolbarIndex) && inv.inventory[toolbarIndex].ItemData.PlaceablePrefab != null) {
                currentItem = inv.inventory[toolbarIndex].ItemData;
                indicator.SetActive(true);
            } else {
                indicator.SetActive(false);
                currentItem = null;
            }


            // get the location of the mouse and then change it to a grid version
            Vector3 location = camera.ScreenToWorldPoint(Input.mousePosition);
            location = new Vector3((float)Math.Floor(location.x) + 0.5f, (float)Math.Floor(location.y) + 0.5f, -1);

            indicator.transform.position = new Vector3(location.x, location.y, -10);
            if (currentItem != null && Input.GetMouseButtonDown(1)) {
                
                // instantiate the object
                Instantiate(currentItem.PlaceablePrefab, location, Quaternion.identity);
                
                // remove the object from the inventory
                player.GetComponent<Inventory>().Remove(toolbarIndex);
            }
        }
    }
}
