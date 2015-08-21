using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CloudSpawner : MonoBehaviour {
    public float startHeight;
    public int chunkSize;
    public int chunkMinPopulation;
    public int chunkMaxPopulation;
    public Transform cloud;
    public Transform trackObject;
    private ChunkHandler handler;
    private Chunk currentChunk;
	
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
	}

    private void Populate(Chunk chunk)
    {
        for(int i = 0; i < UnityEngine.Random.Range(chunkMinPopulation, chunkMaxPopulation); i++)
        {
            Transform obj = (Transform) Instantiate(cloud, new Vector3(0, 0, -100), Quaternion.identity);
            chunk.Objects.Add(obj.gameObject);
            obj.gameObject.GetComponent<RandomSpawn>().setSpawn(chunk.ChunkRect);
            obj.gameObject.GetComponent<Cloud>().Handler = handler;
        }
    }
}
