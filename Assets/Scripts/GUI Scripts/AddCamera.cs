using UnityEngine;
using System.Collections;

public class AddCamera : MonoBehaviour {
	void Start () {
		GetComponent<CanvasGroup> ().alpha = 0f;
		this.GetComponent<Canvas> ().worldCamera = Camera.main;
	}

	void Update(){
		this.GetComponent<Canvas> ().renderMode = RenderMode.WorldSpace;
		GetComponent<CanvasGroup> ().alpha = 1f;
		Destroy (this);
	}
}
