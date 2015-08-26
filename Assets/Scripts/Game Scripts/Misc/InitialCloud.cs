using UnityEngine;
using System.Collections;

public class InitialCloud : MonoBehaviour {
    void Start()
    {
        GetComponent<Cloud>().Check = true;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        GetComponent<Cloud>().Handler = GameObject.FindGameObjectWithTag("Spawner").GetComponent<CloudSpawner>().Handler;
    }
    void Update()
    {
        transform.localScale = new Vector3(1, 1, 1);
        GetComponent<Cloud>().Handler.getChunk(transform.position).Objects.Add(gameObject);
        foreach (GameObject gameObj in GetComponent<Cloud>().Handler.getChunk(transform.position).Objects)
            gameObj.GetComponent<Cloud>().Check = false;
        GetComponent<Cloud>().Check = true;
    }
}
