
using System;
using UnityEngine;

[Serializable]
public class InventoryItem {
    [SerializeField] private ItemData itemData;
    [SerializeField] private int stackSize;

    public ItemData ItemData {
        get => itemData;
        set => itemData = value;
    }

    public int StackSize {
        get => stackSize;
        set => stackSize = value;
    }



    public InventoryItem(ItemData item) {
        itemData = item;
        AddToStack();
    }
    
    public void AddToStack() {
        stackSize++;
    }

    public void RemoveFromStack() {
        stackSize--;
    }
}
