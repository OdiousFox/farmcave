using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
public class ItemData : ScriptableObject {
    [SerializeField] private string displayName;
    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject placeablePrefab;

    public GameObject Prefab {
        get => prefab;
        set => prefab = value;
    }

    public string DisplayName {
        get => displayName;
        set => displayName = value;
    }

    public Sprite Icon {
        get => icon;
        set => icon = value;
    }

    public GameObject PlaceablePrefab {
        get => placeablePrefab;
        set => placeablePrefab = value;
    }
}
