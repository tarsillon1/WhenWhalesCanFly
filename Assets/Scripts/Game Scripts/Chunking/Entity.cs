using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
    private ChunkHandler handler;
    private Chunk currrentChunk;
    private Vector3 lastPos;

	void Update () {
        if (handler == null)
            handler = GetComponent<Handler>().handler;

        if((transform.position != lastPos || currrentChunk == null))
        {
            if (currrentChunk != null && currrentChunk != handler.getChunk(transform.position))
            {
                currrentChunk.Objects.Remove(gameObject);
                currrentChunk = handler.getChunk(transform.position);
                currrentChunk.Objects.Add(gameObject);
                if (handler.AutoDestroyLeft)
                    handler.destoryChunksDirection("left", GetComponent<Handler>().trackObject.position);

                if (handler.AutoDestroyRight)
                    handler.destoryChunksDirection("right", GetComponent<Handler>().trackObject.position);

                if (handler.AutoDestroyDown)
                    handler.destoryChunksDirection("down", GetComponent<Handler>().trackObject.position);

                if (handler.AutoDestroyUp)
                    handler.destoryChunksDirection("up", GetComponent<Handler>().trackObject.position);
            }
            else
                currrentChunk = handler.getChunk(transform.position);
        }
            
        lastPos = transform.position;
	}
}
