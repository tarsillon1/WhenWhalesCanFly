using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {
    public float maxHeight;
    public float currentHeight;
    private bool direction;

	void Update () {
        if (currentHeight > maxHeight)
        {
            direction = !direction;
            currentHeight = 0;
        }

        currentHeight += transform.up.normalized.y / 2;

        if (direction)
            transform.position +=  transform.up.normalized / 2 * Time.deltaTime;
        if (!direction)
            transform.position -= transform.up.normalized / 2 * Time.deltaTime;
	}
}
