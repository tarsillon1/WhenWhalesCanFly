using UnityEngine;
using System.Collections;

public class PlayButtonAction : MonoBehaviour {
	private bool active;
	private bool created;
	private float distance;
	private Transform next;
	public Transform gui;
	public GameObject canvas;

	void Update () {
		if (active) {
			if(!created){
				created = true;
				next = (Transform) Instantiate(gui, new Vector3(canvas.transform.position.x , canvas.transform.position.y, 90), Quaternion.identity);
			}
			next.position = new Vector3(canvas.transform.position.x + 25, canvas.transform.position.y, 90);
			distance += Camera.main.transform.right.x /2;
			Camera.main.transform.Translate( Camera.main.transform.right /2);
			if(distance >= 25){
                Camera.main.GetComponent<CameraMovement>().lockCamera = true;
				Destroy(canvas);
			}
		}
	}

	public void setA(){
		active = true;
	}
}
