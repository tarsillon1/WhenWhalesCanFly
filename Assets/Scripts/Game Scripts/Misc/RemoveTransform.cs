using UnityEngine;
using System.Collections;

public class RemoveTransform : MonoBehaviour {
	void Update () {
        transform.parent = null;
    }
}
