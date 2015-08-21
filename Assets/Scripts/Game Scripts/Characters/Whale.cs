using UnityEngine;
using System.Collections;

public class Whale : MonoBehaviour {
    private bool grounded;
    public GameObject cloud;

    void OnTriggerExit2D(Collider2D col)
    {
            grounded = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
            grounded = true;
        if(cloud != col.gameObject)
        {
            cloud = col.gameObject;
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
