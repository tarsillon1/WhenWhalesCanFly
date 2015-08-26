using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public Transform trackObject;
    public bool lockCamera;

    private Vector3 lastPos = Vector3.zero;
    private BasicSettings settings;

    void Start()
    {
        settings = GameObject.FindGameObjectWithTag("Settings").GetComponent<BasicSettings>();
    }

	void Update () {
        if (trackObject != null)
        {
            if (lockCamera && lastPos != Vector3.zero)
                transform.position += trackObject.position - lastPos;
            lastPos = trackObject.position;
        }

        if (settings.gameStart && transform.position.y <= settings.baseGUIHeight)
            lockCamera = false;

        if (!lockCamera)
            lastPos = Vector3.zero;
	}
}
