using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedingFarm : MonoBehaviour
{
    // public Transform grassblock;
    private GameObject currentBlockType;
    public GameObject[] blockTypes;

    [Tooltip("true")]
    public bool SnapToGrid = true;

    public int width = 128;
    public int depth = 128;
    public int heightScale = 20;
    public int detailScale = 20;

   


    void Start()
    {

        generateTerrain();

    }

    //Funcion que genera el terreno
    void generateTerrain()
    {
        //var rnd = new Random();
        //int seed = (int)* 10;
        int seed = Random.Range(1, 254);
        for (int z = 0; z <= depth; z++)
        {
            for (int x = 0; x <= width; x++)
            {
                int y =(int) Mathf.PerlinNoise((x + seed) / detailScale, (seed + z) / detailScale) * heightScale;
                Vector3 blockPos = new Vector3(x,y,z);

                if( y > 15)
                {
                    Instantiate(blockTypes[0], blockPos, Quaternion.identity);
                }else if(y > 5)
                {
                    Instantiate(blockTypes[1], blockPos, Quaternion.identity);
                }
                else
                {
                    Instantiate(blockTypes[2], blockPos, Quaternion.identity);
                }

            }
        }
        

    }

   
    void Update()
    {

    }
}