using UnityEngine;
using System.Collections.Generic;

public class Chunk{
	private Rect chunkRect;
    private List<GameObject> objects = new List<GameObject>();

    public Chunk(Rect rect)
    {
        ChunkRect = rect;
    }

    public bool inChunk(Vector2 pos)
    {
        if (chunkRect.Contains(pos))
        {
            return true;
        }
        return false;
    }

    public Rect ChunkRect
	{
        get
        {
            return chunkRect;
        }

        set
        {
            chunkRect = value;
        }
    }

    public List<GameObject> Objects
    {
        get
        {
            return objects;
        }

        set
        {
            objects = value;
        }
    }
}
