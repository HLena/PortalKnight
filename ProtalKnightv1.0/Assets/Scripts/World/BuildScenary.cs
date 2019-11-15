using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScenary : MonoBehaviour
{
    // public Transform grassblock;

    bool inventoryEnabled = false;
    private GameObject currentBlockType;
    public GameObject[] blocks;
    public GameObject[] trees;
    //public GameObject[] treeTypes;

    [Tooltip("true")]
    public bool SnapToGrid = true;
    public int sizeX;
    public int sizeZ;

    public int groundHeight;
    public float terDetail;
    public float terHeight;
    int seed;

    public float amp = 10f;
	public float freq = 10f;
   

    bool seeded = false;
	public GameObject player;

	private Vector3 myPos;

	int currentX = 0;
	int currentZ = 0;
	bool finishedTerrain;
	public bool useRunningTerrain = false;
    int randomTree;
    int randomTypeTree;
    Transform environmentTransform;

    void Start()
    {
        //myPos = this.transform.position;
        seed = Random.Range(100000, 999999);
        generateTerrain();
        environmentTransform = GameObject.FindGameObjectWithTag("World").transform;


    }
   
    //Funcion que genera el terreno
    void generateTerrain(){
    	
    	for( float x = 0; x < sizeX; x++)
    	{
    		for(int z = 0; z < sizeZ; z++)
    		{
                int maxY = (int)(Mathf.PerlinNoise((x / 2 + seed) / terDetail, (z / 2 + seed) / terDetail) * terHeight);
                //float y = Mathf.PerlinNoise((seed + myPos.x + x) /freq,(myPos.z + z)/freq)*amp;
                maxY += groundHeight;
                /*randomTree = Random.Range(1000, 9999);
                if(randomTree % 3 == 0 && randomTree % 5 == 1)
                {   randomTypeTree = Random.Range(0, 2);
                    GameObject tree = Instantiate(trees[randomTypeTree], new Vector3(x, maxY, z), Quaternion.identity) as GameObject;
                    tree.transform.SetParent(GameObject.FindGameObjectWithTag("World").transform);
                }
                else
                { 
                    GameObject grass = Instantiate(blocks[0], new Vector3(x, maxY, z), Quaternion.identity) as GameObject;
                    grass.transform.SetParent(GameObject.FindGameObjectWithTag("World").transform);

                }*/
                GameObject grass;
                Vector3 posGrass = new Vector3(x,maxY,z);
                GameObject blockGrass = blocks[Random.Range(0, 3)];
                int chance = Random.Range(0, 100);
                if (chance < 3)
                {
                    grass = Instantiate(blocks[4], posGrass, Quaternion.identity) as GameObject;
                    grass.transform.SetParent(environmentTransform);
                    CreateTree(posGrass);
                }
                else
                {
                    grass = Instantiate(blockGrass, posGrass, Quaternion.identity) as GameObject;
                    grass.transform.SetParent(environmentTransform);

                }
                //Debug.Log("grass: "+ posGrass);

                for (int y = 0; y < maxY; y++)
                //for (int y = maxY -1; y <= maxY - groundHeight; y--)
                {
                    int dirtLayers = Random.Range(1, 5);
                    if (y >= maxY - dirtLayers)
                    {
                        GameObject dirt = Instantiate(blocks[5], new Vector3(x, y, z), Quaternion.identity) as GameObject;
                        dirt.transform.SetParent(GameObject.FindGameObjectWithTag("World").transform);                       

                    }
                    else
                    {
                        GameObject stone = Instantiate(blocks[6], new Vector3(x, y, z), Quaternion.identity) as GameObject;
                        stone.transform.SetParent(environmentTransform);
                    }
                }

                if (x == (int)(sizeX / 2) && z == (int)(sizeZ / 2))
                {
                    Instantiate(player, new Vector3(x, maxY + 3, z), Quaternion.identity);
                }



            }
    	}

    }

    void CreateTree(Vector3 pos)
    {
        //Debug.Log("tree: " + pos);
        GameObject tree = blocks[Random.Range(7, 9)];
        tree.transform.SetParent(environmentTransform);
        tree.name = "tree";
        //new Vector3((float)0.5,0.5,0.5);
        GameObject wood = Instantiate(tree, new Vector3(pos.x, (float)(pos.y + 0.6), pos.z), Quaternion.identity);
        wood.transform.SetParent(environmentTransform);

    }
    
    void Update()
    {
       
    }
}
