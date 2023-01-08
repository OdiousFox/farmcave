using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Breakable : MonoBehaviour {
    [SerializeField] private int durability = 1;
    [SerializeField] private float dropForce = 100f;
    [SerializeField] private int amount = 3;
    [SerializeField] private List<GameObject> drops;
    // [SerializeField] private int sturdiness = 1;

    public int Amount {
        get => amount;
        set => amount = value;
    }

    private void OnMouseDown() {
        durability--;
        if (durability <= 0) {
            Destroy(gameObject);
            InstantiateDrops(amount);
        }
    }

    void InstantiateDrops(int amount) {
        for (int i = 0; i < amount; i++) {
            
            GameObject drop = Instantiate(drops[0], transform.position, Quaternion.identity);
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            drop.GetComponent<Rigidbody2D>().AddForce((dropDirection * dropForce));
        }
    }
}
