using UnityEngine;
using System.Collections;

public class AttachFountain : MonoBehaviour {
    private bool done;
    private float time;

	void Update () {
        if (!done)
        {
            done = true;
            GameObject.FindGameObjectWithTag("Water Fountain").GetComponent<Fountain>().start();
            GameObject.FindGameObjectWithTag("Water Fountain").transform.position = transform.GetChild(3).position;
        }

        time += Time.deltaTime;

        if (time >= 4.5)
        {
            GameObject.FindGameObjectWithTag("Water Fountain").GetComponent<Fountain>().stop();
            
            Destroy(gameObject);
        }
    }	
}
