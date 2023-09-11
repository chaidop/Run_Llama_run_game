using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    public int width;// = 256;
    public int height;// = 256;
    public int depth;// = 20;
    public float amplitude;//the amplitude of the heights

    public int canGenerate = 1;
    public float scale;// = 100.0f;
    protected int arrayIndex = 0;
    public float offsetΖ;
    public float offsetY;

    public float terrainSpeed;
    public Transform ground;
    public Transform llama;
    public GameObject newTerrain1;
    public Terrain newTerrain;
    public Vector3 PositionOffset = new Vector3(10, 10, 10);

    void Start()
    {

        offsetΖ = Random.Range(0f, 999f);
        offsetY = Random.Range(0f, 999f);
        if (transform.position.x < ground.position.x)//create a road for the llama(the terrain shall be flat here)
        {
            arrayIndex = (int)-(transform.position.x - ground.position.x);
        }
        Terrain terrain = gameObject.GetComponent<Terrain>();

        //Debug.Log("Name " + terrain.name);
        terrain.allowAutoConnect = true;

        TerrainData newTerrainData = (TerrainData)Object.Instantiate(newTerrain.terrainData);
        //Terrain.activeTerrain.terrainData = newTerrainData;
        terrain.terrainData = GenerateTerrain(newTerrainData);

        /*
        if (allTer.Length > 1)
        {
            TerrainData newTerrainData = (TerrainData)Object.Instantiate(newTerrain.terrainData);
            Terrain.activeTerrain.terrainData = newTerrainData;
            TerrainCollider tc = Terrain.activeTerrain.gameObject.GetComponent<TerrainCollider>();
            tc.terrainData = newTerrainData;
            terrain.terrainData = GenerateTerrain(newTerrainData);
        }

        if (terrain == null)
        {
            Debug.Log("no terrain created");
        }

        terrain.terrainData = GenerateTerrain(td);*/

        //Terrain[] allTer = Terrain.activeTerrains;
        //Debug.Log("Active terrains " + allTer.Length);
        //terrain.SetNeighbors(null, allTer[0], null, null);
        //Debug.Log(terrain.topNeighbor.name);
        /*
        for (int i = 0; i < allTer.Length; i++)
        {
            if (i + 1 < allTer.Length)
            {
                allTer[i].SetNeighbors(null, null, null, allTer[i + 1]);
                //Debug.Log("======== TERRAIN NEIGHBOR NAME =====" + allTer[i + 1].name);

            }

        }
        */


    }

    public static void mirror(float[][] theArray)
    {
        for (int i = 0; i < (theArray.Length / 2); i++)
        {
            float[] temp = theArray[i];
            theArray[i] = theArray[theArray.Length - i - 1];
            theArray[theArray.Length - i - 1] = temp;
        }
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
        {
            terrainData.heightmapResolution = width + 1;
            terrainData.size = new Vector3(width, depth, height);

            terrainData.SetHeights(0, 0, GenerateHeight());

            return terrainData;
        }

        float[,] GenerateHeight()
        {
            float[,] heights = new float[width, height];
            for (int x =0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    heights[x, y] = CalculateHeight(x, y);
                }
            }
        //smoothly get terrain height to 0 on the edges
        //gia thn katw (notia) plevra
        for (int x = 50 -1, i = 0; x >= 0; x--, i++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = heights[x, y] - (heights[x, y] / 50) * i;
            }
        }
        //gia thn panw (voreia) plevra 
        for (int i = 0, x = width - 50; x < width; x++, i++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = heights[x, y] - (heights[x, y]/50)*i;
            }
        }

        //to have 0 height on the road
        //Debug.Log(ground.position.x);
        //Debug.Log(width + ground.position.x +1);
        for (int x = 0; x < width; x++)
            {
                for (int y = arrayIndex - 1; y < arrayIndex + 2; y++)
                {
                    heights[x, y] = 0;
                }
            }
        return heights;
        }

        private float CalculateHeight(int x, int y)
        {
        float xCoord = (float)x / width * scale;// + offsetΖ;
        float yCoord = (float)y / height * scale;// + offsetY;

            return Mathf.PerlinNoise(xCoord, yCoord);
        }
   

    void Update()
    {
        transform.position -= new Vector3(0.0f, 0.0f, terrainSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 360, 0), 100 * Time.deltaTime);
        //Terrain terrain = GetComponent<Terrain>();
        //terrain.terrainData = GenerateTerrain(terrain.terrainData);
        //offsetΖ += Time.deltaTime * terrainSpeed;
        if ((transform.position.z + height <= (height*0.95f)) && (canGenerate == 1))
        {
            Terrain terrain = gameObject.GetComponent<Terrain>();
            if (terrain == null)
            {
                Debug.Log("no terrain created");
            }

            Instantiate(newTerrain1, new Vector3(terrain.transform.position.x, terrain.transform.position.y, height * 0.93f), Quaternion.identity);
            
            /*
            TerrainData newTerrainData = (TerrainData)Object.Instantiate(newTerrain.terrainData);
            Terrain.activeTerrain.terrainData = newTerrainData;
            TerrainCollider tc = Terrain.activeTerrain.gameObject.GetComponent<TerrainCollider>();
            tc.terrainData = newTerrainData;
            
            clone.AddComponent<TerrainMovement>();

            TerrainMovement terrainMovement = clone.GetComponent<TerrainMovement>();
            terrainMovement.llama = llama;
            terrainMovement.ground = ground;
            terrainMovement.newTerrain = newTerrain;
            terrainMovement.newTerrain1 = newTerrain1;
            terrainMovement.terrainSpeed = terrainSpeed;*/

            //clone.GetComponent<TerrainMovement>().llama = llama;

            //terrain.SetNeighbors(null, null, null, clone);
            // terrain.Flush();
            canGenerate = 0;
        }
        if (transform.position.z + height <= llama.position.z)
        {
            //Debug.Log("Terrain destroyed!!!!!");
            canGenerate = 1;
            Destroy(gameObject);
        }
    }
}
