using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour {
    [SerializeField] private List<Sprite> Stages;
    private int stage = 0;
    private void OnEnable() {
        WorldTime.passDay += AdvanceStage;
    }
    
    private void OnDisable() {
        WorldTime.passDay -= AdvanceStage;
    }

    private void AdvanceStage() {
        if (stage < Stages.Count) {
            transform.GetComponent<SpriteRenderer>().sprite = Stages[stage];
            if (stage + 1 == Stages.Count) transform.GetComponent<Breakable>().Amount = 3;
            stage++;
        }
    }
}
