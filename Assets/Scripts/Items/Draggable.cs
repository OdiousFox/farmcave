using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    [SerializeField] private Image image;
    private Transform parentAfterDrag;

    public static event Action<InventorySlot, InventorySlot> OnItemMove; 
    public static event Action<InventorySlot> OnItemDrop; 

    
    public void OnBeginDrag(PointerEventData eventData) {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root.transform.root);
        transform.
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.SetParent(parentAfterDrag);
        transform.SetSiblingIndex(1);
        GameObject dropped = eventData.pointerEnter;
        if (dropped != null && dropped.transform.parent != transform.parent) {
            OnItemMove?.Invoke(transform.parent.GetComponent<InventorySlot>(), dropped.transform.parent.GetComponent<InventorySlot>());
        }
        
        if (dropped == null) OnItemDrop?.Invoke(transform.parent.GetComponent<InventorySlot>());
        
        transform.position = parentAfterDrag.position;
        image.raycastTarget = true;
    }

    public void OnPointerEnter() {
        
    }
}
