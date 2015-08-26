using UnityEngine;
using System.Collections;

public class WhaleGameStart : MonoBehaviour {
    private float time;
    public float startTime;
    private bool added;
    public Vector2 force;

	void Update () {
        time += Time.deltaTime;

        if (time >= startTime && !added)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
            added = true;
        }
	}
}
