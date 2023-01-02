using System;
using System.Collections.Generic;
using Items.Stone;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using Random = UnityEngine.Random;


public class Inventory : MonoBehaviour {
    public static event Action<Dictionary<int ,InventoryItem>> OnInventoryChange; 
    public static event Action<bool> OnBackPackFull; 

    public Dictionary<int ,InventoryItem> inventory = new Dictionary<int ,InventoryItem>();
    private bool full = false;
    private ItemData lastItemData;

    public bool Full {
        get => full;
        set => full = value;
    }

    private void OnEnable() {
        ItemCollect.OnCollected += Add;
        Draggable.OnItemMove += switchLocation;
        Draggable.OnItemDrop += dropItem;
    }
    
    private void OnDisable() {
        ItemCollect.OnCollected -= Add;
        Draggable.OnItemMove -= switchLocation;
        Draggable.OnItemDrop -= dropItem;

    }

    public void Add(ItemData itemData) {
        lastItemData = itemData;
        // Debug.Log("add" + itemData);   
        int contains = ContainsItem(itemData, 50);
        if (contains != -1) {
            // Debug.Log("inventoryitem " + item + "    itemdata " + itemData);
            inventory[contains].AddToStack();
            OnInventoryChange?.Invoke(inventory);
        } else {
            InventoryItem newItem = new InventoryItem(itemData);
            int location = 30;
            for (int i = 0; i < 30; i++) {
                if (!inventory.ContainsKey(i)) {
                    location = i;
                    i = 30;
                }
            }
            if (location < 30) {
                inventory.Add(location, newItem);
                OnInventoryChange?.Invoke(inventory);
                if (location >= 29) {
                    full = true;
                    OnBackPackFull?.Invoke(true);
                };
            }

        }
    }

    public void Remove(int location) {
        if (inventory.TryGetValue(location, out InventoryItem item)) {
            item.RemoveFromStack();
            if (item.stackSize == 0) {
                inventory.Remove(location);
                OnInventoryChange?.Invoke(inventory);
                full = false;
            }
        }
    }

    private int ContainsItem(ItemData itemData, int maxStackSize) {
        foreach (var item in inventory) {
            if (item.Value.itemData.name.Equals(itemData.name) && item.Value.stackSize < maxStackSize) {
                return item.Key;
            }
        }

        return -1;
    }

    private void switchLocation(InventorySlot start, InventorySlot destination) {
        int di = destination.Index;
        int si = start.Index;
        if (inventory.ContainsKey(di)) {
            InventoryItem tempDestination = inventory[di];
            InventoryItem tempStart = inventory[si];
            inventory.Remove(si);
            inventory.Remove(di);
            inventory.Add(si, tempDestination);
            inventory.Add(di, tempStart);

        } else {
            inventory.Add(di, inventory[si]);
            inventory.Remove(si);
            
        }
        foreach (var VARIABLE in inventory) {
            Debug.Log(VARIABLE.Value.itemData.name);
        }
        OnInventoryChange?.Invoke(inventory);

    }

    private void dropItem(InventorySlot slot) {
        InventoryItem item = inventory[slot.Index];
        GameObject itemPrefab = item.itemData.Prefab;
        int stack = item.stackSize;

        InstantiateDrops(itemPrefab, stack);
        
        inventory.Remove(slot.Index);
        OnInventoryChange?.Invoke(inventory);
    }
    
    void InstantiateDrops(GameObject item, int amount) {
        for (int i = 0; i < amount; i++) {
            GameObject drop = Instantiate(item, transform.position, Quaternion.identity);
            drop.GetComponent<Magnetized>().OnFirstPass = true; 
            drop.GetComponent<Magnetized>().WaitFirstCollect = true; 
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            drop.GetComponent<Rigidbody2D>().AddForce((dropDirection * 200f));
        }
    }
}
