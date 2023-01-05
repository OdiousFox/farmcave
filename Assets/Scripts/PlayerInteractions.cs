using UnityEngine;

public class PlayerInteractions : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col) {
        
        ICollectible collectible = col.GetComponent<ICollectible>();
        bool goIn = false;
        var magnet = col.GetComponent<Magnetized>();
        if (magnet != null) goIn = col.GetComponent<Magnetized>().WaitFirstCollect;
        if (collectible != null && !goIn) {
            //Debug.Log("Onfirstpass:  " + col.GetComponent<Magnetized>().OnFirstPass + " collider :   " + col);
            if (!GetComponent<Inventory>().Full) {
                collectible.Collect();
            }
        }

        if(magnet != null)col.GetComponent<Magnetized>().WaitFirstCollect = false;
    }
}