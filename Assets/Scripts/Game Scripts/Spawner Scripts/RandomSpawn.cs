using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {
    public void setSpawn(Rect container)
    {
        Bounds bounds = GetComponent<SpriteRenderer>().sprite.bounds;
        float maxX = container.position.x + (bounds.size.x / 2);
        float minX = (container.position.x + container.size.x) - (bounds.size.x / 2);
        float maxY = (container.position.y + container.size.y) - (bounds.size.y / 2);
        float minY = (container.position.y) + (bounds.size.y / 2);

        transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 10);
    }
}
