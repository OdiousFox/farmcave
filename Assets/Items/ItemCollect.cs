using UnityEngine;

namespace Items.Stone {
    public class ItemCollect : MonoBehaviour, ICollectible {

        public static event HandleStoneCollected OnCollected;
        public delegate void HandleStoneCollected(ItemData itemData);

        public ItemData itemData;
        

        public void Collect() {
            OnCollected?.Invoke(itemData);
            Destroy(gameObject);        
        }
    }
}
