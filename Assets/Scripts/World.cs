using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class World : MonoBehaviour {

    [SerializeField] private Tilemap map;
    [SerializeField] private GameObject[] dirtSpawnables;
    [SerializeField] private GameObject[] grassSpawnables;
    [SerializeField] private Tile[] dirtTiles;
    [SerializeField] private Tile[] grassTiles;

    private List<TileType> tileTypes = new List<TileType>();

    private void Start() {
        BoundsInt bounds = map.cellBounds;
        TileBase[] allTiles = map.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++) {
            for (int y = 0; y < bounds.size.y; y++) {
                TileBase tile = allTiles[x + y * bounds.size.x];
                float relativeX = x + map.origin.x + 0.5f;
                float relativeY = y + map.origin.y + 0.5f;
                if (tile == dirtTiles[0] || tile == dirtTiles[1] || tile == dirtTiles[2]) {
                    tileTypes.Add(new TileType(new Vector2(relativeX, relativeY), 0));
                } else if (tile == grassTiles[0] || tile == grassTiles[1]) {
                    tileTypes.Add(new TileType(new Vector2(relativeX, relativeY), 1));
                }
                // if (tile != null) {
                //     Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                // } else {
                //     Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                // }
            }
        } 
        InstantiateDirtSpawnables();
        InstantiateGrassSpawnables();
    }

    void InstantiateDirtSpawnables() {
        foreach (var type in tileTypes) {
            float rand = Random.Range(0f, 10f);
            if (type.Type == 0 && rand < 0.5f) {
                Instantiate(dirtSpawnables[0], new Vector3(type.Position.x, type.Position.y, -3), Quaternion.identity);
            }
        }
    }
    
    void InstantiateGrassSpawnables() {
        foreach (var type in tileTypes) {
            float rand = Random.Range(0f, 10f);
            // Debug.Log("current =: " + type.type + " and " +type.position);
            if (type.Type > 0.9f && type.Type < 1.1f && rand < 1f) {
                Instantiate(grassSpawnables[0], new Vector3(type.Position.x, type.Position.y, -1), Quaternion.identity);
            } else if (type.Type > 0.9f && type.Type < 1.1f && rand < 2f) {
                Instantiate(grassSpawnables[1], new Vector3(type.Position.x, type.Position.y, -1), Quaternion.identity);
            } else if (type.Type > 0.9f && type.Type < 1.1f && rand < 2.5f) {
                Instantiate(grassSpawnables[2], new Vector3(type.Position.x, type.Position.y, -1), Quaternion.identity);
            }
        }
    }
    
    
    
    public List<TileType> TileTypes {
        get => tileTypes;
        set => tileTypes = value;
    }
}
