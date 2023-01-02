using System.Collections;
using System.Collections.Generic;
public class Chunk{
    private List<int> tileData = new List<int>();
    private int size;
    private int x;
    private int y;

    public Chunk(int x, int y, int size = 16) {
        this.x = x;
        this.y = y;
        this.size = size;
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                tileData.Add(1);
            }
        }
    }

    public List<int> TileData {
        get => tileData;
        set => tileData = value;
    }

    public int X => x;

    public int Y => y;
    
    public int Size => size;
}
