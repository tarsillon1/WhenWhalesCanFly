using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CloudSpawner : MonoBehaviour {
    private ChunkHandler handler;
    private Chunk currentChunk;
    private Vector2 trackPos;

    public float startHeight;
    public int chunkSize;
    public int chunkMinPopulation;
    public int chunkMaxPopulation;
    public float minDistance;
    public Transform cloud;
    public Transform trackObject;
	
    void Start()
    {
        handler = new ChunkHandler(chunkSize);
    }

	void Update () {
	    if(currentChunk == null || !currentChunk.inChunk(trackObject.position))
        {
            //Get current chunk
            currentChunk = handler.getChunk(trackObject.position);
            //Make sure all render chunks have been created
            handler.getRenderChunks(new Vector2(trackObject.position.x, trackObject.position.y));
            //Prerenderchunks
            if (trackObject.position.x - trackPos.x > 0)
                handler.getPreRenderChunk("right", trackObject.position);
            if (trackObject.position.y - trackPos.y > 0)
                handler.getPreRenderChunk("up", trackObject.position);
            if (trackObject.position.y - trackPos.y < 0)
                handler.getPreRenderChunk("down", trackObject.position);
            //Dispose of left chunks
            handler.destoryChunksDirection("left", trackObject.position);
            //Fill empty chunks if they meet hieght requirement
            foreach(Chunk chunk in handler.getEmptyChunks())
            {
                if(chunk.ChunkRect.position.y > startHeight)
                {
                    Populate(chunk);
                }
            }
            
        }
        trackPos = trackObject.position;
	}

    private void Populate(Chunk chunk)
    {
        for(int i = 0; i < UnityEngine.Random.Range(chunkMinPopulation, chunkMaxPopulation); i++)
        {
            Transform obj = (Transform) Instantiate(cloud, new Vector3(0, 0, -100), Quaternion.identity);
            chunk.Objects.Add(obj.gameObject);
            obj.gameObject.GetComponent<RandomSpawn>().setSpawn(chunk.ChunkRect);
            obj.gameObject.GetComponent<Cloud>().Handler = handler;
            obj.gameObject.GetComponent<Cloud>().MinDistance = minDistance;
        }
    }
}
