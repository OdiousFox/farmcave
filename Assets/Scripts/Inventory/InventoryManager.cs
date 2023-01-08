using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    public GameObject slotPrefab;
    public Image Backpack;
    private bool backPackopen = false;
    private Dictionary<int, InventoryItem> localInventory = new Dictionary<int ,InventoryItem>();
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(30);

    private void OnEnable() {
        Inventory.OnInventoryChange += DrawInventory;
    }
    
    private void OnDisable() {
        Inventory.OnInventoryChange -= DrawInventory;
    }
    
    void ResetInventory() {
        foreach (var slot in inventorySlots) {
            slot.ClearSlot();
        }
    }

    void DrawInventory(Dictionary<int ,InventoryItem> inventory) {
        ResetInventory();
        localInventory = inventory;
        if (backPackopen) {
            Backpack.gameObject.SetActive(true);
        } else {
            Backpack.gameObject.SetActive(false);
        }
        for (int i = 0; i < 30; i++) {
            //Debug.Log("i = " + i + "  | count = " + inventorySlots.Count + "  | inventory[i] = " + inventory[i] + "  | inventorySlots = " + inventorySlots[i]);
            //Debug.Log("inventory.count = " + inventory.Count + "  | inventory.capacity = " + inventory.Capacity + "inventorySlots.count = " + inventorySlots.Count + "  | inventorySlots.capacity = " + inventorySlots.Capacity);
            if (backPackopen) {
                if (inventory.TryGetValue(i, out InventoryItem item)) {
                    inventorySlots[i].DrawSlot(item);
                }
            } else {
                if (i < 10 && inventory.TryGetValue(i, out InventoryItem item)) {
                    inventorySlots[i].DrawSlot(item);
                } 
            }
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            // Debug.Log("i am alive");
            backPackopen = !backPackopen;
            DrawInventory(localInventory);
        }
    }
}
