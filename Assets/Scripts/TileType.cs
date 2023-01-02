using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileType {
    private Vector2 position;
    private int type;
    private GameObject data;

    public TileType(Vector2 position, int type) {
        this.position = position;
        this.type = type;
    }

    public Vector2 Position {
        get => position;
        set => position = value;
    }

    public int Type {
        get => type;
        set => type = value;
    }

    public GameObject Data {
        get => data;
        set => data = value;
    }
}
