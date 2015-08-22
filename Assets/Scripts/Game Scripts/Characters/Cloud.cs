using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{
    private bool check;
    private ChunkHandler handler;
    private Chunk chunk;
    private float minDistance;

    public float maxSize;
    public float minSize;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0);
        transform.localScale = new Vector3(Random.Range(minSize, maxSize), Random.Range(minSize, maxSize), 1);
    }

    void Update()
    {
        if (chunk == null)
            chunk = handler.getChunk(transform.position);

        if (!check)
        {
            bool unFixed = false;
            foreach (GameObject c in chunk.Objects)
            {
                    if ((GetComponent<Collider2D>().bounds.Intersects(c.GetComponent<Collider2D>().bounds)
                        || Vector2.Distance(transform.position, c.transform.position) < minDistance)
                        && c != gameObject)
                        GetComponent<RandomSpawn>().setSpawn(chunk.ChunkRect);
            }

            foreach (GameObject c in chunk.Objects)
            {
                if ((GetComponent<Collider2D>().bounds.Intersects(c.GetComponent<Collider2D>().bounds)
                    || Vector2.Distance(transform.position, c.transform.position) < minDistance)
                    && c != gameObject)
                    unFixed = true;
            }
            if (!unFixed)
            {
                check = true;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }
        }


    }

    public ChunkHandler Handler
    {
        get
        {
            return handler;
        }

        set
        {
            handler = value;
        }
    }

    public float MinDistance
    {
        get
        {
            return minDistance;
        }

        set
        {
            minDistance = value;
        }
    }
}
