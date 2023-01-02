using UnityEngine;

namespace Items.Wood {
    public class Wood : MonoBehaviour, ICollectible {

        public static event HandleStoneCollected OnWoodCollected;
        public delegate void HandleStoneCollected(ItemData itemData);

        public ItemData woodData;

        public void Collect() {
            OnWoodCollected?.Invoke(woodData);
            Destroy(gameObject);        
        }
    }
}