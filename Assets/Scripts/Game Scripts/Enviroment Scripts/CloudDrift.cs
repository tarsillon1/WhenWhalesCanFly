using UnityEngine;
using System.Collections;

public class CloudDrift : MonoBehaviour {
	void Update () {
        transform.position -= transform.right * Time.deltaTime;
	}
}
