using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour {
    [SerializeField] private Image icon;
    [SerializeField] private Image backGround;
    [SerializeField] private int index;
    [SerializeField] private TextMeshProUGUI stackSizeText;

    public int Index => index;

    public void ClearSlot() {
        
        icon.enabled = false;
        stackSizeText.enabled = false;
    }

    public void DrawSlot(InventoryItem item) {
        if (item == null) {
            ClearSlot();
            return;
        }
        icon.enabled = true;
        stackSizeText.enabled = true;
        backGround.enabled = true;
        icon.sprite = item.itemData.icon;
        stackSizeText.text = item.stackSize.ToString();
    }
    

    public void HideSlot() {
        icon.enabled = false;
        stackSizeText.enabled = false;
        backGround.enabled = false;
    }
    
}
