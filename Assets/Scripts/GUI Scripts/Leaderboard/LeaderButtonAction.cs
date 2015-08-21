using UnityEngine;
using System.Collections;

public class LeaderButtonAction : MonoBehaviour {
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
				next = (Transform) Instantiate(gui, new Vector3(canvas.transform.position.x, canvas.transform.position.y, 90), Quaternion.identity);
			}
			next.position = new Vector3(canvas.transform.position.x - 25, canvas.transform.position.y, 90);
			distance += Camera.main.transform.right.x / 2;
			Camera.main.transform.Translate( Camera.main.transform.right * -0.5f);
			if(distance >= 25){
				Destroy(canvas);
			}
		}
	}

	public void setA(){
		active = true;
	}
}
