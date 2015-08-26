using UnityEngine;
using System.Collections;

public class ParticleLayer : MonoBehaviour {
    public int layer;
	void Start () {
            // Set the sorting layer of the particle system.
            GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Default";
            GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = layer;
    }
}
