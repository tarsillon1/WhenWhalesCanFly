using UnityEngine;

public class CloudSpawner : MonoBehaviour {
    private ChunkHandler handler;
    private Chunk currentChunk;
    private Vector2 trackPos;
    private Transform trackObject;

    public float startHeight;
    public int chunkSize;
    public int chunkMinPopulation;
    public int chunkMaxPopulation;
    public float minDistance;
    public Transform cloud;

    void Start()
    {
        Handler = new ChunkHandler(chunkSize);
        Handler.AutoDestroyLeft = true;
        trackObject = Camera.main.transform;
    }

	void Update () {
	    if(currentChunk == null || !currentChunk.inChunk(trackObject.position))
        {
            //Get current chunk
            currentChunk = Handler.getChunk(trackObject.position);
            //Make sure all render chunks have been created
            Handler.getRenderChunks(new Vector2(trackObject.position.x, trackObject.position.y));
            //Prerenderchunks
            if (trackObject.position.x - trackPos.x > 0)
                Handler.getPreRenderChunk("right", trackObject.position);
            if (trackObject.position.y - trackPos.y > 0)
                Handler.getPreRenderChunk("up", trackObject.position);
            if (trackObject.position.y - trackPos.y < 0)
                Handler.getPreRenderChunk("down", trackObject.position);
            //Dispose of left chunks
            Handler.destoryChunksDirection("left", trackObject.position);
            //Fill empty chunks if they meet hieght requirement
            foreach(Chunk chunk in Handler.getEmptyChunks())
            {
                if(chunk.ChunkRect.position.y > startHeight)
                {
                    Populate(chunk);
                }
            }
            
        }
        trackPos = trackObject.position;
	}

    void Populate(Chunk chunk)
    {
        for(int i = 0; i < UnityEngine.Random.Range(chunkMinPopulation, chunkMaxPopulation); i++)
        {
            Transform obj = (Transform) Instantiate(cloud, new Vector3(0, 0, -100), Quaternion.identity);
            chunk.Objects.Add(obj.gameObject);
            obj.gameObject.GetComponent<RandomSpawn>().setSpawn(chunk.ChunkRect);
            obj.gameObject.GetComponent<Handler>().handler = Handler;
            obj.gameObject.GetComponent<Handler>().trackObject = trackObject;
            obj.gameObject.GetComponent<Cloud>().MinDistance = minDistance;
        }
    }

    public ChunkHandler Handler
    {
        get
        {
            return handler;
        }

        set
        {
            handler = value;
        }
    }
}
