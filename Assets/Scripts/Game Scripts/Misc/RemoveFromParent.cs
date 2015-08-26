using UnityEngine;
using System.Collections;

public class RemoveFromParent : MonoBehaviour {
    public float x;
	public float y;

	void Start () {
        transform.parent = null;
        if(x == 0)
		    transform.position = new Vector2 (Camera.main.transform.position.x, y);
        else
            transform.position = new Vector2(x, y);
    }

    public void reset()
    {
        if (x == 0)
            transform.position = new Vector2(Camera.main.transform.position.x, y);
        else
            transform.position = new Vector2(x, y);
    }
}
