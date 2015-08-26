using UnityEngine;
using System.Collections;

public class Fountain : MonoBehaviour {
	void Start () {
        stop();
	}
	
	public void stop()
    {
        GetComponent<ParticleSystem>().Stop();
    }

    public void start()
    {
        GetComponent<ParticleSystem>().Play();
    }
}
