using UnityEngine;
using System.Collections;

public class WorldBackground : MonoBehaviour
{
    public float x;
    public float y;
	public float a;

    void Start()
    {
        Bounds bounds = GetComponent<SpriteRenderer>().sprite.bounds;
        float xSize = bounds.size.x;
        float ySize = bounds.size.y;

        transform.localScale = new Vector3(x / xSize, y / ySize, bounds.size.z);

		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, a);
    }
}
