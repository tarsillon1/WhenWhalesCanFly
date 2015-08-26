using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{
    private bool check;
    private ChunkHandler handler;
    private Chunk chunk;
    private float minDistance;
    private float alpha;

    public float maxSize;
    public float minSize;

    void Start()
    {
        alpha = GetComponent<SpriteRenderer>().color.a;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0);
        transform.localScale = new Vector3(Random.Range(minSize, maxSize), Random.Range(minSize, maxSize), 1);
    }

    void Update()
    {
        if (handler == null)
            handler = GetComponent<Handler>().handler;

        if (chunk == null)
            chunk = handler.getChunk(transform.position);

        if (!Check)
        {
            bool unFixed = false;
            foreach (GameObject c in chunk.Objects)
            {
                    if (c.GetComponent<Collider2D>() != null && (GetComponent<Collider2D>().bounds.Intersects(c.GetComponent<Collider2D>().bounds)
                        || Vector2.Distance(transform.position, c.transform.position) < minDistance)
                        && c != gameObject)
                        GetComponent<RandomSpawn>().setSpawn(chunk.ChunkRect);
            }

            foreach (GameObject c in chunk.Objects)
            {
                if (c.GetComponent<Collider2D>() != null && (GetComponent<Collider2D>().bounds.Intersects(c.GetComponent<Collider2D>().bounds)
                    || Vector2.Distance(transform.position, c.transform.position) < minDistance)
                    && c != gameObject)
                    unFixed = true;
            }
            if (!unFixed)
            {
                Check = true;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
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

    public bool Check
    {
        get
        {
            return check;
        }

        set
        {
            check = value;
        }
    }
}
