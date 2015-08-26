using UnityEngine;
using System.Collections;

public class Whale : MonoBehaviour {
    private bool grounded;
    private BasicSettings settings;
    private bool created;

    public GameObject cloud;
    public Transform UI;

    void Start()
    {
        Camera.main.GetComponent<CameraMovement>().trackObject = transform;
        settings = GameObject.FindGameObjectWithTag("Settings").GetComponent<BasicSettings>();
    }

    void Update()
    {
        if(settings.gameStart && transform.position.y < settings.gameOverHeight && !created)
        {
            GameObject.FindGameObjectWithTag("Wave").GetComponent<RemoveFromParent>().reset();
            Instantiate(UI, new Vector3(0, 0, 0), Quaternion.identity);
            created = true;
        }

        if (transform.position.y < 0)
        {
            settings.gameStart = false;
            Destroy(gameObject);
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
            grounded = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
            grounded = true;
        if(cloud != col.gameObject && GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            cloud = col.gameObject;
            GetComponent<Rigidbody2D>().isKinematic = true;
            if (!settings.gameStart)
            {
                settings.gameStart = true;
                GameObject.FindGameObjectWithTag("ControlScheme").GetComponent<PressAndDrag>().rigidBody = GetComponent<Rigidbody2D>();
            }
        }
    }
}
